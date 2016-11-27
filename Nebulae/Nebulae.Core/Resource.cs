/*
 Copyright Richard Lawson, 2016
 */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nebulae.Model {
    public class Resource {

        public Resource(string id, string name, ResourceType type, JObject doc, ICollection<Relationship> relations) {
            _id = String.IsNullOrEmpty(id) ? 0 : Int64.Parse(id);
            _type = type;
            _name = name;
            _document = doc;
            _relations = new HashSet<Relationship>(relations);
        }

        public string ResourceId { get { return _id.ToString(); } }
        public IResourceType ResourceType { get { return _type; } }
        public JObject Document { get { return _document; } }
        public string Name { get { return _name; } }
        public IReadOnlyCollection<Relationship> RelationShips { get { return _relations.ToList().AsReadOnly(); } }

        //public Relationship EstablishRelationship(RelationshipType relationType, Resource target) {
        //    //
        //    var link = new Relationship(relationType, this, target);
        //    AddRelationship(link);
        //    return link;
        //}
        public void AddRelationship(Relationship relation) {
            _relations.Add(relation);
        }
        public void RemoveRelationship(Relationship relation) {
            _relations.Remove(relation);
        }


        private Int64 _id;
        private IResourceType _type;
        private string _name;
        private JObject _document;
        private HashSet<Relationship> _relations;
    }
}