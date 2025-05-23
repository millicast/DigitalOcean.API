using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DomainRecordsClient : IDomainRecordsClient {
        private readonly IConnection _connection;

        public DomainRecordsClient(IConnection connection) {
            _connection = connection;
        }

        #region IDomainRecordsClient Members

        /// <summary>
        /// Retrieve all records configured for a domain
        /// </summary>
        public Task<IReadOnlyList<DomainRecord>> GetAll(string domainName) {
            // docs don't say this is paginated? but it could be so run it thru that anyway
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", domainName)
            };
            return _connection.GetPaginated<DomainRecord>("domains/{name}/records", parameters, "domain_records");
        }

        /// <summary>
        /// Create a new record for a domain.
        /// </summary>
        public Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", domainName)
            };
            return _connection.ExecuteRequest<DomainRecord>("domains/{name}/records", parameters, record,
                "domain_record", Method.Post);
        }

        /// <summary>
        /// Retrieve a specific domain record
        /// </summary>
        public Task<DomainRecord> Get(string domainName, long recordId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", domainName),
                new UrlSegmentParameter ("id", recordId.ToString())
            };
            return _connection.ExecuteRequest<DomainRecord>("domains/{name}/records/{id}", parameters, null, "domain_record");
        }

        /// <summary>
        /// Delete a record for a domain
        /// </summary>
        public Task Delete(string domainName, long recordId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", domainName),
                new UrlSegmentParameter ("id", recordId.ToString())
            };
            return _connection.ExecuteRaw("domains/{name}/records/{id}", parameters, null, Method.Delete);
        }

        /// <summary>
        /// Update an existing record for a domain
        /// </summary>
        public Task<DomainRecord> Update(string domainName, long recordId, Models.Requests.UpdateDomainRecord updateRecord) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", domainName),
                new UrlSegmentParameter ("id", recordId.ToString())
            };
            return _connection.ExecuteRequest<DomainRecord>("domains/{name}/records/{id}", parameters, updateRecord,
                "domain_record", Method.Put);
        }

        #endregion
    }
}
