using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
// Model_User Sample
public class Model_User
{
    public ObjectId _id { set; get; }
    public string name { set; get; }

    public int ActiveConnection { set; get; }
    public string Username { private set; get; }
    public string Email { private set; get; }
    public string ShaPassword { private set; get; }

    //Possible Methods ...
}
