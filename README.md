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
