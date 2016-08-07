using System;
using System.Collections.Generic;
using System.Linq;

namespace Nebulae.Model {
    public class RelationshipType : IRelationshipType {

        public RelationshipType() {
            _id = Guid.NewGuid();
        }
        public RelationshipType(string id, string name, IResourceType source, IResourceType target) {
            _id = Guid.Parse(id);
            Name = name;
            _source = source;
            _target = target;
        }

        public string ResourceId { get { return _id.ToString(); } }
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

        private Guid _id;
        private IResourceType _source, _target;


    }
}
