using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfEnumAttribute))]
public class ShowIfEnumPropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (ShouldShow(property))
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        else
        {
            return -EditorGUIUtility.standardVerticalSpacing; 
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (ShouldShow(property))
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    private bool ShouldShow(SerializedProperty property)
    {
        ShowIfEnumAttribute showIf = (ShowIfEnumAttribute)attribute;

        SerializedProperty enumProp = property.serializedObject.FindProperty(showIf.enumName);

        if (enumProp == null)
        {
            Debug.LogError($"ShowIfEnum: Could not find enum field '{showIf.enumName}' on object of type {property.serializedObject.targetObject.GetType()}.");
            return true; 
        }
        
        return enumProp.intValue == showIf.enumValue;
    }
}