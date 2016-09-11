using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nebulae.Model
{
    public interface IResourceType {
        Newtonsoft.Json.Schema.JSchema Schema { get; set; }
        string ResourceTypeId { get; }
        string Name { get; }
        IResourceType ParentType { get; }
        bool IsA(IResourceType resourceType);
    }
}
