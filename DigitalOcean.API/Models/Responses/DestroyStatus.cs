using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses;

public class DestroyStatus {

    /// <summary>
    /// An object containing information about a resource scheduled for deletion.
    /// </summary>
    [JsonProperty("droplet")]
    public DestroyItemStatus Droplet { get; set; }

    /// <summary>
    /// An object containing additional information about resource related to a Droplet requested to be destroyed.
    /// </summary>
    [JsonProperty("resources")]
    public DestroyStatusResources Resources { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format indicating when the requested action was completed.
    /// </summary>
    [JsonProperty("completed_at")]
    public string CompletedAt { get; set; }

    /// <summary>
    /// A count of the associated resources that failed to be destroyed, if any.
    /// </summary>
    [JsonProperty("failures")]
    public int Failures { get; set; }
}

public class DestroyItemStatus {

    /// <summary>
    /// The unique identifier for the resource scheduled for deletion.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the resource scheduled for deletion.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format indicating when the resource was destroyed if the request was successful.
    /// </summary>
    [JsonProperty("destroyed_at")]
    public string DestroyedAt { get; set; }

    /// <summary>
    /// A string indicating that the resource was not successfully destroyed and providing additional information.
    /// </summary>
    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }
}

public class DestroyStatusResources {

    [JsonProperty("floating_ips")]
    public List<DestroyItemStatus> FloatingIps { get; set; }

    [JsonProperty("reserved_ips")]
    public List<DestroyItemStatus> ReservedIps { get; set; }

    [JsonProperty("snapshots")]
    public List<DestroyItemStatus> Snapshots { get; set; }

    [JsonProperty("volumes")]
    public List<DestroyItemStatus> Volumes { get; set; }

    [JsonProperty("volume_snapshots")]
    public List<DestroyItemStatus> VolumeSnapshots { get; set; }
}
