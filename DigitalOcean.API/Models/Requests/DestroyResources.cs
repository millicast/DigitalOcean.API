using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests;

public class DestroyResources {

    // DEPRECATED
    //[JsonProperty("floating_ips")]
    //public List<string> FloatingIps { get; set; }

    /// <summary>
    /// An array of unique identifiers for the reserved IPs to be scheduled for deletion.
    /// </summary>
    [JsonProperty("reserved_ips")]
    public List<string> ReservedIps { get; set; }

    /// <summary>
    /// An array of unique identifiers for the snapshots to be scheduled for deletion.
    /// </summary>
    [JsonProperty("snapshots")]
    public List<string> Snapshots { get; set; }

    /// <summary>
    /// An array of unique identifiers for the volumes to be scheduled for deletion.
    /// </summary>
    [JsonProperty("volumes")]
    public List<string> Volumes { get; set; }

    /// <summary>
    /// An array of unique identifiers for the volume snapshots to be scheduled for deletion.
    /// </summary>
    [JsonProperty("volume_snapshots")]
    public List<string> VolumeSnapshots { get; set; }
}
