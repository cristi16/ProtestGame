using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class EnumUtil
{
    public static List<T> GetValues<T>()
    {
        Array array = Enum.GetValues(typeof(T));
        return new List<T>((T[])array);
    }

    public static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static T GetRandomEnumValue<T>()
    {
        List<T> values = GetValues<T>();

        int index = UnityEngine.Random.Range(0, values.Count - 1);

        return values[index];
    }
}
