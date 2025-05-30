using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class VolumesClient : IVolumesClient {
        private readonly IConnection _connection;

        public VolumesClient(IConnection connection) {
            _connection = connection;
        }

        #region IVolumesClient Members

        /// <summary>
        /// Create a new Block Storage volume
        /// </summary>
        public Task<Volume> Create(Models.Requests.Volume volume) {
            return _connection.ExecuteRequest<Volume>("volumes", null, volume, "volume", Method.Post);
        }

        /// <summary>
        /// Create a new Snapshot from this Block Storage volume
        /// </summary>
        public Task<Snapshot> CreateSnapshot(string volumeId, Models.Requests.VolumeSnapshot snapshot) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", volumeId)
            };
            return _connection.ExecuteRequest<Snapshot>("volumes/{id}/snapshots", parameters, snapshot, "snapshot", Method.Post);
        }

        /// <summary>
        /// Delete a Block Storage volume
        /// </summary>
        public Task Delete(string volumeId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", volumeId)
            };
            return _connection.ExecuteRaw("volumes/{id}", parameters, null, Method.Delete);
        }

        /// <summary>
        /// Delete a Block Storage volume by name and region
        /// </summary>
        public Task DeleteByName(string name, string region) {
            var parameters = new List<Parameter> {
                new QueryParameter("name", name),
                new QueryParameter("region", region)
            };
            return _connection.ExecuteRaw("volumes", parameters, null, Method.Delete);
        }

        /// <summary>
        /// Retreive an individual Block Storage volume
        /// </summary>
        public Task<Volume> Get(string volumeId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", volumeId)
            };
            return _connection.ExecuteRequest<Volume>("volumes/{id}", parameters, null, "volume");
        }

        /// <summary>
        /// Retreive all Block Storage volumes on your account
        /// </summary>
        public Task<IReadOnlyList<Volume>> GetAll() {
            return _connection.GetPaginated<Volume>("volumes", null, "volumes");
        }

        /// <summary>
        /// Retreive an individual Block Storage volume by name and region
        /// </summary>
        public Task<IReadOnlyList<Volume>> GetByName(string name, string region) {
            var parameters = new List<Parameter> {
                new QueryParameter("name", name),
                new QueryParameter("region", region)
            };
            return _connection.GetPaginated<Volume>("volumes", parameters, "volumes");
        }

        /// <summary>
        /// Retreive all snapshots created from a Block Storage volume
        /// </summary>
        public Task<IReadOnlyList<Snapshot>> GetSnapshots(string volumeId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", volumeId)
            };
            return _connection.GetPaginated<Snapshot>("volumes/{id}/snapshots", parameters, "snapshots");
        }

        #endregion
    }
}
