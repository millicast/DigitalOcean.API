using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDropletsClient {
        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAll();

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName);

        /// <summary>
        /// To retrieve a list of Droplets that are running on the same physical server.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAllNeighbors(long dropletId);

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        Task<IReadOnlyList<Kernel>> GetKernels(long dropletId);

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetSnapshots(long dropletId);

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetBackups(long dropletId);

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        Task<IReadOnlyList<Action>> GetActions(long dropletId);

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        Task<Droplet> Create(Models.Requests.Droplet droplet);

        /// <summary>
        /// To create multiple Droplets.
        /// A Droplet will be created for each name you send using the associated information.
        /// Up to ten Droplets may be created at a time.
        /// </summary>
        Task<IReadOnlyList<Droplet>> Create(Models.Requests.Droplets droplets);

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        Task<Droplet> Get(long dropletId);

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        Task Delete(long dropletId);

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        Task DeleteByTag(string tagName);

        /// <summary>
        /// To list the associated billable resources that can be destroyed along with a Droplet.
        /// The response will contain snapshots, volumes, and volume_snapshots keys.
        /// Each will be set to an array of objects containing information about the associated resources.
        /// </summary>
        Task<DestroyResources> GetDestroyResources(long dropletId);

        /// <summary>
        /// To destroy a Droplet along with a sub-set of its associated resources.
        /// The body of the request should include reserved_ips, snapshots, volumes, or volume_snapshots keys each set to an array of IDs for the associated resources to be destroyed.
        /// The IDs can be found by querying the Droplet's associated resources. Any associated resource not included in the request will remain and continue to accrue changes on your account.
        /// Use the status endpoint to check on the success or failure of the destruction of the individual resources.
        /// </summary>
        Task Destroy(long dropletId, Models.Requests.DestroyResources resources);

        /// <summary>
        /// To check on the status of a request to destroy a Droplet with its associated resources.
        /// </summary>
        Task<DestroyStatus> GetDestroyStatus(long dropletId);

        /// <summary>
        /// If the status of a request to destroy a Droplet with its associated resources reported any errors, it can be retried.
        /// Only one destroy can be active at a time per Droplet.
        /// </summary>
        Task RetryDestroy(long dropletId);

        /// <summary>
        /// To retrieve a list of any Droplets that are running on the same physical hardware.
        /// </summary>
        [System.Obsolete("Deprecated on December 17th, 2019")]
        Task<IReadOnlyList<Droplet>> ListDropletNeighbors();

        /// <summary>
        /// To retrieve a list of all Droplets that are co-located on the same physical hardware.
        /// This will be set to an array of arrays. Each array will contain a set of Droplet IDs for Droplets that share a physical server.
        /// An empty array indicates that all Droplets associated with your account are located on separate physical hardware.
        /// </summary>
        Task<IReadOnlyList<List<long>>> ListDropletNeighborIds();
    }
}
