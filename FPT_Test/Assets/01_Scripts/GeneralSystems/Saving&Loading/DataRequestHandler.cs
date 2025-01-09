using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEditor.PackageManager;

public class DataRequestHandler
{
    public Action<IDataAccess, Type> OnRequestData;

    private FileManager fileManager;
    private Dictionary<IDataAccess, Type> dataOrders;
    //private List<DataOrder> dataOrders;

    public DataRequestHandler(FileManager fileManager)
    {
        this.fileManager = fileManager;
        SubscripteToDataRequest();
        //fileManager.OnReturnData += ReturnData;
    }

    private void SubscripteToDataRequest()
    {
        List<IDataAccess> dataAccesses = FindAllDataAccesObjects();

        foreach (IDataAccess dataAccess in dataAccesses)
        {
            dataAccess.OnLoadData += SendDataRequest;
        }
    }

    private void SendDataRequest(IDataAccess client, Type order)
    {
        Debug.Log(client.ToString() + " needs the data : " + order.ToString());
        OnRequestData?.Invoke(client, order);
    }

    private void ReturnData(IDataAccess client, object order)
    {

    }

    private List<IDataAccess> FindAllDataAccesObjects()
    {
        IEnumerable<IDataAccess> dataobjectsAcces = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IDataAccess>();
        return new List<IDataAccess>(dataobjectsAcces);
    }



}
