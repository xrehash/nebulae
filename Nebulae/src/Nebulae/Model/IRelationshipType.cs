using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nebulae.Model
{
    public interface IRelationshipType
    {
        string RelationshipTypeId { get; }
        string Name { get; }
        IResourceType SourceType { get; }
        IResourceType TargetType { get; }
    }
}
