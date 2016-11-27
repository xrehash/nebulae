/*
 Copyright Richard Lawson, 2016
 */

using Newtonsoft.Json.Schema;
using System;
using System.Linq;

namespace Nebulae.Model {
    public class ResourceType : IResourceType {
        private Int64 _resourceid;
        private IResourceType _parentType;
        private JSchema _schema;

        public ResourceType(IResourceType parent = null) {
            _resourceid = 0;
            _parentType = parent;
        }
        public ResourceType(string id, string name, IResourceType parent, JSchema schema) {
            _schema = schema;
            _resourceid = Int64.Parse(id);
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
