using System;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public Action OnReturnData;

    private List<IDataAccess> listDataAccess;
    private Dictionary<Type, string> savedObjects;
    private Dictionary<object, Type> activeDataRequest;
    private DataRequestHandler dataRequestHandler;

    private Loader loader;
    private Saver saver;


    private void Start()
    {
        saver = new Saver();
        loader = new Loader();

        dataRequestHandler = new DataRequestHandler(this);
        savedObjects = new Dictionary<Type, string>();

        dataRequestHandler.OnRequestData += HandleDataRequest;
        //dataRequestHandler.OnGenericEvent += TestGeneric;
    }

    private void HandleDataRequest(IDataAccess client, Type order)
    {
        Debug.Log("I Have received the order");
        //savedObjects.Add(order, "hallo");
        //order data = LoadData<order>(typeof(order));

        //object data = loader.LoadData("DataTestWow");
        //DataTestObject data2 = (DataTestObject)data;
        //Debug.Log("loader test : " + data);

    }

    private void TestGeneric<T>()
    {
        T data = loader.LoadData<T>("string");
    }

    private void SaveData()
    {

    }


}
