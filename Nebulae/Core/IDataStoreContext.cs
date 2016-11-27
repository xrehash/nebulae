using System;
using System.Linq;
using MongoDB.Driver;

namespace Nebulae.Model
{
    interface IDataStoreContext
    {
        T GetResourceType<T>(string id) where T : IResourceType;
        void PutResourceType<T>(T resourceType) where T : IResourceType;
    }

    public class DataStoreContext : IDataStoreContext, IDisposable
    {
        private const string RESOURCE_TYPES = "resource_types";
        private const string NEBULAE_DATABASE = "nebulae";
        private IMongoClient _client;
        private IMongoDatabase _db;

        public DataStoreContext(string dbUrl)
        {
            _client = new MongoClient(dbUrl);
            _db = _client.GetDatabase(NEBULAE_DATABASE);
        }

        public T GetResourceType<T>(string id) where T : IResourceType
        {
            var bag = _db.GetCollection<T>(RESOURCE_TYPES);
            var filter = Builders<T>.Filter.Eq("_id",id);
            var find = bag.Find<T>(filter);
            return find.First<T>();
        }

        public void PutResourceType<T>(T resourceType) where T : IResourceType
        {
            var bag = _db.GetCollection<T>(typeof(T).Name);
            bag.InsertOne(resourceType);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_client != null)
                    {
                        _client = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataStoreContext() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
