using System;
public interface IDataAccess
{
    object Data { get; set; }
    public Action<IDataAccess,Type> OnLoadData { get; set; }

}

