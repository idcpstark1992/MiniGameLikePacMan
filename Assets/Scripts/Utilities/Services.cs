using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public  class Services 
{
    public static       Services Instance => _instance ?? (_instance = new Services());
    private static      Services _instance;
    private readonly    Dictionary<Type, object> _services;

    private Services()
    {
        _services = new Dictionary<Type, object>();
    }

    public void AddService<T>(T _registerService)
    {
        var mType = typeof(T);
        Assert.IsFalse(_services.ContainsKey(mType),
                       $"Service {mType} already registered");

        _services.Add(mType, _registerService);
    }

    public T GetService<T>()
    {
        var mType = typeof(T);
        if (!_services.TryGetValue(mType, out var Outservice))
        {
            throw new Exception($"Service {mType} Does not Exist!");
        }
        return (T)Outservice;
    }
}
