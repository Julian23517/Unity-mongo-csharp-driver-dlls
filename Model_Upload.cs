using MongoDB.Driver;
using System.Collections.Generic;
using UnityEngine;

public class Model_Upload : MonoBehaviour
{
    private const string MONGO_URI = "mongodb://127.0.0.1:27017";
    private const string DATABASE_NAME = "testDatabase";
    private MongoClient client;
    private IMongoDatabase db;

    void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
        IMongoCollection<Model_User> userCollection = db.GetCollection<Model_User>("collectionName");
        Model_User e = new Model_User();
        e.name = "hope";
        userCollection.InsertOne(e);
        List<Model_User> userModelList = userCollection.Find(user => true).ToList();
        Model_User[] userAsap= userModelList.ToArray();
        foreach(Model_User asap in userAsap)
        {
            print(asap.name);
        }
    }


}
