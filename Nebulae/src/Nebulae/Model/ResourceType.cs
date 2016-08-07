using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Schema;

namespace Nebulae.Model {
    public class ResourceType : IResourceType {
        private Guid _resourceid;
        private IResourceType _parentType;
        private JSchema _schema;

        public ResourceType(IResourceType parent = null) {
            _resourceid = Guid.NewGuid();
            _parentType = parent;
        }
        public ResourceType(string id, string name, IResourceType parent, JSchema schema) {
            _schema = schema;
            _resourceid = Guid.Parse(id);
            _parentType = parent;
            Name = name;
        }
        public string ResourceId
        {
            get
            {
                return _resourceid.ToString();
            }
        }
        public string Name { get; protected set; }
        public IResourceType ParentType { get { return _parentType; } }
        public bool IsA(IResourceType resourceType) {
            return ResourceId.Equals(resourceType.ResourceId)
                || (ParentType != null && ParentType.IsA(resourceType));
        }

        public JSchema Schema {
            get {
                return _schema; }
            set            {
                if (_schema == null)
                    _schema = value;
                else
                    throw new InvalidOperationException("Cannot modify Schema");
            }

        }
    }
}
