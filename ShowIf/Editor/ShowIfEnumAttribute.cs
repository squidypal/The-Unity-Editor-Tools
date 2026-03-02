using UnityEngine;

public class ShowIfEnumAttribute : PropertyAttribute
{
    public string enumName;
    public int enumValue;

    public ShowIfEnumAttribute(string enumName, object enumValue)
    {
        this.enumName = enumName;
        this.enumValue = (int)enumValue; 
    }
}