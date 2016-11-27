/*
 Copyright Richard Lawson, 2016
 */

using System;
using System.Linq;

namespace Nebulae.Model {
    public class Relationship {
        
        public Relationship(IRelationshipType rType, Resource src, Resource tgt) :this(0.ToString(), rType, src, tgt) {  }
        public Relationship(string relationshipId, IRelationshipType rType, Resource src, Resource tgt) {
            if (src.ResourceType.IsA(rType.SourceType) && tgt.ResourceType.IsA(rType.TargetType)) {
                _id = Int64.Parse(relationshipId);
                _type = rType;
                _source = src;
                _target = tgt;
                src.AddRelationship(this);
            }
            else {
                throw new ArgumentException("Mismatched relationship types.", "rType");
            }
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) {
            if(obj.GetType() ==  typeof(Relationship) ){
                var rObj = obj as Relationship;

                return rObj.Id == this.Id || (rObj.Source == Source && rObj.Target == Target);
            }else{

                return base.Equals(obj);
            }
        }

        public Int64 Id
        {
            get
            {
                return _id;
            }
        }
        public IRelationshipType RelationshipType
        {
            get
            {
                return _type;
            }
        }
        public Resource Source
        {
            get
            {
                return _source;
            }
        }
        public Resource Target
        {
            get
            {
                return _target;
            }
        }
        private Int64 _id;
        private IRelationshipType _type;
        private Resource _source;
        private Resource _target;


    }
}
