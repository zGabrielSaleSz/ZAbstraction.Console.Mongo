using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAbstraction.Mongo;
using ZAbstraction.Mongo.Attributes;

namespace ZAbstraction.Demo.Entities
{
    // this notation is responsible for defining the collection name for this entity
    [ZMongoCollection("collectionName")]
    public class User : ZMongoBase
    {
        // you don't have to create the id field, It will come from ZMongoBase
        //public ObjectId id { get; set; }
        public string fullName { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
