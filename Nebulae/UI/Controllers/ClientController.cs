using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nebulae.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("/client/a")]
    public class ClientController : Controller
    {
        private IDataStoreContext db;

        public ClientController(IDataStoreContext dataStore)
        {
            this.db = dataStore;
        }

        [HttpGet]
        [Route("resource_types")]
        public IEnumerable<IResourceType> GetResourceTypes(int page = 1, int pageSize = 1000, int skip = 0)
        {
            
            return new IResourceType[0];
        }
    }
}
