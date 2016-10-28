using UnityEngine;
using System;


public abstract class PreferencesProfileBase
{
    protected string profilePrefix = "/";


    public abstract void Init();

    public virtual void Save<Type>(string key, Type data)
    {
        key = profilePrefix + key;

        if (typeof(Type) == typeof(int))
            PlayerPrefs.SetInt(key, (int)Convert.ChangeType(data, typeof(int)));

        if (typeof(Type) == typeof(float))
            PlayerPrefs.SetFloat(key, (float)Convert.ChangeType(data, typeof(float)));

        if (typeof(Type) == typeof(string))
            PlayerPrefs.SetString(key, (string)Convert.ChangeType(data, typeof(string)));
    }

    public virtual Type Load<Type>(string key)
    {
        key = profilePrefix + key;

        if (typeof(Type) == typeof(int))
            return (Type)Convert.ChangeType(PlayerPrefs.GetInt(key), typeof(Type));

        if (typeof(Type) == typeof(float))
            return (Type)Convert.ChangeType(PlayerPrefs.GetFloat(key), typeof(Type));

        if (typeof(Type) == typeof(string))
            return (Type)Convert.ChangeType(PlayerPrefs.GetString(key), typeof(Type));

        return default(Type);
    }
}
