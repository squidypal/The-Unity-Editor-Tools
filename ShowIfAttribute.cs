using UnityEngine;
using System;

public class ShowIfAttribute : PropertyAttribute
{
    public string BoolFieldName { get; private set; }

    public ShowIfAttribute(string boolFieldName)
    {
        BoolFieldName = boolFieldName;
    }
}