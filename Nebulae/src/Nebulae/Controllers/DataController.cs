using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nebulae.Service;
using Nebulae.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nebulae.Controllers
{
    [Route("/ds")]
    public class DataController : Controller
    {
        private DataService _ds;
        public DataController(DataService ds) {
            this._ds = ds;
        }

        // GET: api/values
        [HttpGet]
        [Route("resourceTypes")]
        public IEnumerable<IResourceType> Get()
        {
            return _ds.GetResourceTypes();
        }

        
    }
}
