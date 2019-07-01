# Unity-mongo-csharp-driver-dlls

These are the dlls that you have to include in a Plugins folder inside of your Unity Project.

Then you can access your Database like this (replace username, password, DATABASE_NAME and 127.0.0.1 (127.0.0.1 only, if you host your database elsewhere)):

```script
using MongoDB.Driver;

private const string MONGO_URI = "mongodb://username:password@127.0.0.1:27017";
private const string DATABASE_NAME = "testDatabase";
private MongoClient client;
private IMongoDatabase db;

client = new MongoClient(MONGO_URI);
db = client.GetDatabase(DATABASE_NAME);
        
```
```script
```
# Reference Collection:
Replace Model_User with your Model Class  
Replace collectionName with the name of the collection you want to reference  
make sure that the Model Class has public getter on all Properties and a public ObjectId _id with public getter and setter  
```script
 private readonly IMongoCollection<Model_User> userCollection = db.GetCollection<Model_User>("collectionName");
```

```script
// Model_User Sample
public class Model_User {
        public ObjectId _id { set; get; }
        
        public int ActiveConnection { set; get; }
        public string Username { private set; get; }
        public string Email { private set; get; }
        public string ShaPassword { private set; get; }
        
        //Possible Methods ...
}
```

# Get All Models from Collection
Replace Model_User with your Model Class that represents a document in the Collection   
Replace userCollection with the referenced collection  
You Could replace "true" with a condition that matches the specific documents you want to get
```script
 List<Model_User> userModelList = userCollection.Find(user => true).ToList();
```

# Get a Single Model from Collection (or null if no match was found)
Replace Model_User with your Model Class that represents a document in the collection   
Replace userCollection with the referenced collection   
Replace "user._id.Equals(id)" with whatever your condition should be that matches the document   
```script
 Model_User modelUser = userCollection.Find(user => user._id.Equals(id)).SingleOrDefault();
```

# Insert One Document to Collection (Post)
Replace userCollection with the referenced collection   
Replace newModelUser with the Model you want to insert into the collection   
```script
 userCollection.InsertOne(newModelUser);
```

# Replace One Document in Collection (Update)
Replace userCollection with the referenced collection   
Replace newModelUser with the new version of your model you want to update  
```script
 userCollection.FindOneAndReplace(user => user._id == newModelUser._id, newModelUser);
```

# Update Many Documents in Collection
Replace userCollection with the referenced collection  
Replace "user.ActiveConnection != 0" with the condition that should match the documents you want to update  
Replace "user => user.ActiveConnection, 0" with the Attribute you want to change and the value you want to set to that Attribute  
```script
 // on all users that have a ActiveConnection different from 0, set ActiveConnection to 0
 userCollection.UpdateMany(user => user.ActiveConnection != 0, Builders<Model_User>.Update.Set(user => user.ActiveConnection, 0));
```
