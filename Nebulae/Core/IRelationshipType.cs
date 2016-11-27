/*
 Copyright Richard Lawson, 2016
 */

using System;
using System.Linq;

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
