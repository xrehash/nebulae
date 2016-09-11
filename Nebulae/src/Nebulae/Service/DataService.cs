using Microsoft.Extensions.Configuration;
using Nebulae;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Nebulae.Model;
using System.Data.Entity;
using System.Data;

namespace Nebulae.Service
{
    public class DataService : IDisposable {

        private readonly Db _db;

        public DataService(IConfigurationRoot _config) {
            _db = new Db(_config.GetConnectionString("db"));
            //_db.Database.BeginTransaction(IsolationLevel.Snapshot);
        }

        public IEnumerable<ResourceType> GetResourceTypes() {
            return _db.ResourceTypes.AsEnumerable<ResourceType>();
        }
        public void SaveResourceType(ResourceType entity) {
            _db.ResourceTypes.Add(entity);
        }

        public IEnumerable<Resource> GetResources() {
            return _db.Resources.AsEnumerable<Resource>();
        }

        public void SaveResource(Resource artifact) {
            _db.Resources.Add(artifact);
        }



        public void Dispose() {
            if (_db != null) {
                _db.SaveChanges();
                _db.Dispose();
            }
        }
        public class Db : DbContext {

            public Db(string connString) : base(connString) {
                base.Configuration.LazyLoadingEnabled = false;
            }
            public DbSet<ResourceType> ResourceTypes {get;set;}
            public DbSet<RelationshipType> RelationshipTypes { get; set; }
            public DbSet<Resource> Resources { get; set; }
            public DbSet<Relationship> Relationships { get; set; }
        }
    }
}

namespace Nebulae {
}