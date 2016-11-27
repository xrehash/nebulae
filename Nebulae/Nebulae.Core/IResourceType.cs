/*
 Copyright Richard Lawson, 2016
 */

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
