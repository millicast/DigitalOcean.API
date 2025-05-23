using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DatabasesClientTest {
        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var database = new Models.Requests.DatabaseCluster();
            client.Create(database);
            factory.Received().ExecuteRequest<DatabaseCluster>("databases", null, database, "database", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.Get("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<DatabaseCluster>("databases/{id}", parameters, null, "database");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.GetAll();
            factory.Received().GetPaginated<DatabaseCluster>("databases", null, "databases");
        }

        [Fact]
        public void CorrectRequestForGetAllByTag() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.GetAllByTag("awesome");
            var parameters = Arg.Is<List<Parameter>>(list => list[0].Name == "tag_name" && (string)list[0].Value == "awesome");
            factory.Received().GetPaginated<DatabaseCluster>("databases", parameters, "databases");
        }


        [Fact]
        public void CorrectRequestForResize() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var resize = new Models.Requests.ResizeDatabase();
            client.Resize("1", resize);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/resize", parameters, resize, Method.Post);
        }

        [Fact]
        public void CorrectRequestForMigrate() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var migrate = new Models.Requests.MigrateDatabase();
            client.Migrate("1", migrate);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/migrate", parameters, migrate, Method.Post);
        }

        [Fact]
        public void CorrectRequestForMaintenance() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var maintenance = new Models.Requests.MaintenanceWindow();
            client.Maintenance("1", maintenance);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/maintenance", parameters, maintenance, Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetBackups() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.GetBackups("1");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<DatabaseBackup>("databases/{id}/backups", parameters, "backups");
        }

        [Fact]
        public void CorrectRequestForRestore() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var backup = new Models.Requests.DatabaseBackup();
            client.Restore(backup);

            factory.Received().ExecuteRequest<DatabaseCluster>("databases", null, backup, "database", Method.Post);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.Delete("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForCreateReplica() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var replica = new Models.Requests.DatabaseReplica();
            client.CreateReplica("1", replica);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<DatabaseReplica>("databases/{id}/replicas", parameters, replica, "replica", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetReplica() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.GetReplica("1", "example");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "example");
            factory.Received().ExecuteRequest<DatabaseReplica>("databases/{id}/replicas/{name}", parameters, null, "replica");
        }

        [Fact]
        public void CorrectRequestForGetAllReplicas() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetAllReplicas("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<DatabaseReplica>("databases/{id}/replicas", parameters, "replicas");
        }

        [Fact]
        public void CorrectRequestForDeleteReplica() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.DeleteReplica("1", "example");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "example");
            factory.Received().ExecuteRaw("databases/{id}/replicas/{name}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForAddUser() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var user = new Models.Requests.DatabaseUser();
            client.AddUser("1", user);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<DatabaseUser>("databases/{id}/users", parameters, user, "user", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetUser() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.GetUser("1", "name");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRequest<DatabaseUser>("databases/{id}/users/{name}", parameters, null, "user");
        }

        [Fact]
        public void CorretRequestForGetAllUsers() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetAllUsers("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<DatabaseUser>("databases/{id}/users", parameters, "users");
        }

        [Fact]
        public void CorrectRequestForRemoveUser() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.RemoveUser("1", "name");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRaw("databases/{id}/users/{name}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForResetUserAuth() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var body = new Models.Requests.DatabaseResetUserAuth();
            client.ResetUserAuth("1", "name", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRequest<DatabaseUser>("databases/{id}/users/{username}/reset_auth", parameters, body, "user", Method.Post);
        }

        [Fact]
        public void CorrectRequestForAddDatabase() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            var database = new Models.Requests.Database();
            client.AddDatabase("1", database);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<Database>("databases/{id}/dbs", parameters, database, "db", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetDatabase() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetDatabase("1", "name");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRequest<Database>("databases/{id}/dbs/{name}", parameters, null, "db");
        }

        [Fact]
        public void CorrectRequestForGetAllDatabases() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetAllDatabases("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<Database>("databases/{id}/dbs", parameters, "dbs");
        }

        [Fact]
        public void CorrectRequestForDeleteDatabase() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.DeleteDatabase("1", "name");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRaw("databases/{id}/dbs/{name}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForAddConnectionPool() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            var pool = new Models.Requests.ConnectionPool();
            client.AddConnectionPool("1", pool);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<ConnectionPool>("databases/{id}/pools", parameters, pool, "pool", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetAllConnectionPools() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetAllConnectionPools("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<ConnectionPool>("databases/{id}/pools", parameters, "pools");
        }

        [Fact]
        public void CorrectRequestForGetConnectionPool() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.GetConnectionPool("1", "name");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRequest<ConnectionPool>("databases/{id}/pools/{name}", parameters, null, "pool");
        }

        [Fact]
        public void CorrectRequestForDeleteConnectionPool() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);
            client.DeleteConnectionPool("1", "name");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "name");
            factory.Received().ExecuteRaw("databases/{id}/pools/{name}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForUpdateFirewallRules() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var body = new Models.Requests.UpdateDatabaseFirewallRules();
            client.UpdateFirewallRules("1", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/firewall", parameters, body, Method.Put);
        }

        [Fact]
        public void CorrectRequestForListFirewallRules() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.ListFirewallRules("1");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<DatabaseFirewallRule>("databases/{id}/firewall", parameters, "rules");
        }

        [Fact]
        public void CorrectRequestForRetrieveRedisEviction() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.RetrieveEvictionPolicy("1");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<RedisEvictionPolicy>("databases/{id}/eviction_policy", parameters, null, null);
        }

        [Fact]
        public void CorrectRequestForConfigureRedisEviction() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var body = new Models.Requests.RedisEvictionPolicy();
            client.ConfigureEvictionPolicy("1", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/eviction_policy", parameters, body, Method.Put);
        }

        [Fact]
        public void CorrectRequestForRetrieveMySqlModes() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            client.RetrieveSqlModes("1");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<MySqlModes>("databases/{id}/sql_mode", parameters, null, null);
        }

        [Fact]
        public void CorrectRequestForConfigureMySqlModes() {
            var factory = Substitute.For<IConnection>();
            var client = new DatabasesClient(factory);

            var body = new Models.Requests.MySqlModes();
            client.ConfigureSqlModes("1", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("databases/{id}/sql_mode", parameters, body, Method.Put);
        }
    }
}
