/*
 Copyright Richard Lawson, 2016
 */

using System;
using System.Linq;

namespace Nebulae.Model {
    public class RelationshipType : IRelationshipType {

        public RelationshipType() {
            _id = 0;
        }
        public RelationshipType(string id, string name, IResourceType source, IResourceType target) {
            _id = Int64.Parse(id);
            Name = name;
            _source = source;
            _target = target;
        }

        public string RelationshipTypeId { get { return _id.ToString(); } }
        public string Name { get; protected set; }
        public IResourceType SourceType
        {
            get
            {
                return _source;
            }
        }
        public IResourceType TargetType
        {
            get
            {
                return _target;
            }
        }

        private Int64 _id;
        private IResourceType _source, _target;


    }
}
