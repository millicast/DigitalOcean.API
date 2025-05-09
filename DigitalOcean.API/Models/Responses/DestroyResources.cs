using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses;

public class DestroyResources {

    [JsonProperty("floating_ips")]
    public List<DestroyResource> FloatingIps { get; set; }

    [JsonProperty("reserved_ips")]
    public List<DestroyResource> ReservedIps { get; set; }

    [JsonProperty("snapshots")]
    public List<DestroyResource> Snapshots { get; set; }

    [JsonProperty("volumes")]
    public List<DestroyResource> Volumes { get; set; }

    [JsonProperty("volume_snapshots")]
    public List<DestroyResource> VolumeSnapshots { get; set; }
}

public class DestroyResource {
    /// <summary>
    /// The unique identifier for the resource associated with the Droplet.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the resource associated with the Droplet.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The cost of the resource in USD per month if the resource is retained after the Droplet is destroyed.
    /// </summary>
    [JsonProperty("cost")]
    public string Cost { get; set; }
}
