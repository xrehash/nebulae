using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

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
        public string ResourceTypeId
        {
            get
            {
                return _resourceid.ToString();
            }
        }
        public string Name { get; protected set; }
        public IResourceType ParentType { get { return _parentType; } }
        public bool IsA(IResourceType resourceType) {
            return ResourceTypeId.Equals(resourceType.ResourceTypeId)
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
