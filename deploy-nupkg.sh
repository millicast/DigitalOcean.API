#!/usr/bin/env bash

set -o nounset -o errexit -o pipefail
shopt -s inherit_errexit

### REQUIREMENTS:
### dotnet-sdk-8.0
### jq

### SECRETS:
### NUPKG_PUBLISH_URL
### NUPKG_PUBLISH_APIKEY

function main() {
  dotnet tool restore
  versionJson="$(dotnet dotnet-gitversion /config .gitversion.yml)"
  semVer="$(jq -r '.SemVer' <<< "${versionJson}")"
  assemblySemVer="$(jq -r '.AssemblySemVer' <<< "${versionJson}")"
  informationalVersion="$(jq -r '.InformationalVersion' <<< "${versionJson}")"

  dotnet restore

  dotnet clean -c Release
  dotnet build -c Release -p:Version="${assemblySemVer}" -p:InformationalVersion="${informationalVersion}" -p:IncludeSourceRevisionInInformationalVersion=false

  dotnet test -c Release --no-build

  mkdir -p dist/
  rm -f dist/*
  dotnet pack -c Release -p:PackageVersion="${semVer}" -o dist/ --no-build

  for nupkg in dist/*.nupkg; do
    dotnet nuget push "${nupkg}" --source "${NUPKG_PUBLISH_URL}" --api-key "${NUPKG_PUBLISH_APIKEY}"
  done
}

main "$@"
