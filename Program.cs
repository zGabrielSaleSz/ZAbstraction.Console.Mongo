using MongoDB.Bson;
using MongoDB.Driver;
using System;
using ZAbstraction.Demo.Entities;
using ZAbstraction.Mongo;

namespace ZAbstraction.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // please use breakpoints to see things happening

            //setting up your connection
            ZMongo.Configurate("mongodb+srv://username:myPassword@clustername.domain.mongodb.net/myFirstDatabase?retryWrites=true&w=majority", "databaseName", "ZAbstraction.Demo.Entities.*");

            // insert example
            User user = Insert();

            // update example
            Update(user.id);

            // delete example
            Delete(user);

            //important observations
            //- you can use the normal methods from the MongoDriver library, once that a collection can be provided using ZMongo.Instance.GetCollection<Entity>()
            //- you can create sub objects in your entities, and that subobjects should be initialized in the constructor
            //- lists must be initialized as well in the constructor
        }
        public static User Insert()
        {
            // please take a look in Entities/User.cs
            User user = new User();
            user.fullName = "Gabriel Sales";
            user.email = "gabriel.gomes6@fatec.sp.gov.br";
            user.password = "xxxx,itsasecret";
            user.birthday = new DateTime(1900, 1, 1); //oh, I'm not that old, :(

            // insert command will perform the insert and return the last inserted ID
            user.Insert();

            Console.WriteLine($"The id will be filled on entity as well, see -> {user.id.ToString()}");
            return user;
        }
        public static void Update(ObjectId id)
        {
            // that is how you find the collection using your entity,
            // ZMongo.Instance it's a singleton instance
            User userFound = ZMongo.Instance.GetCollection<User>().Find(u => u.id == id).FirstOrDefault();
            userFound.birthday = new DateTime(1999, 1, 1);//Now my birthday year is correct :D

            // remember that Update() will update all the fields, means it's always recommended you select the entity from database before change any attribute
            userFound.Update();
        }
        public static void Delete(User user)
        {
            //for deletion, it's quite simple, you can find the user using the id, or just call delete from your object, since that your object have a filled and valid id
            user.Delete();
        }
    }
}
