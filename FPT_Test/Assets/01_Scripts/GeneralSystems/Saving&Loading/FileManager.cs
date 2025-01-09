using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
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
        dataRequestHandler = new DataRequestHandler(this);
        savedObjects = new Dictionary<Type, string>();

        dataRequestHandler.OnRequestData += HandleDataRequest;
    }

    private object LoadData(Type order )
    {
        //savedObjects.TryGetValue(datatype, out string path);
        loader.LoadData<>(order.Name);


        return dataOrder;
    }

    private void HandleDataRequest(IDataAccess client, Type order)
    {
        Debug.Log("I Have received the order");
        savedObjects.Add(order, "hallo");
        order data = LoadData<order>(typeof(order));

    }

    private void SaveData()
    {

    }


}
