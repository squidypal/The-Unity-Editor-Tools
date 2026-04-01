using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = attribute as ShowIfAttribute;
        // 1. Find the SerializedProperty for the boolean field
        SerializedProperty booleanProperty = property.serializedObject.FindProperty(showIf.BoolFieldName);

        if (booleanProperty != null && booleanProperty.propertyType == SerializedPropertyType.Boolean)
        {
            // 2. Check the boolean's value
            if (booleanProperty.boolValue)
            {
                // 3. If true, draw the property
                EditorGUI.PropertyField(position, property, label, true);
            }
            // If false, it doesn't draw anything, effectively making it invisible
        }
        else
        {
            // Fallback: If the boolean field is not found, draw the property anyway and show a warning.
            EditorGUI.PropertyField(position, property, label, true);
            Debug.LogWarning("ShowIfAttribute error: Boolean field '" + showIf.BoolFieldName + "' not found.");
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = attribute as ShowIfAttribute;
        SerializedProperty booleanProperty = property.serializedObject.FindProperty(showIf.BoolFieldName);

        // Crucial step: If the boolean is false, the height must be 0, otherwise it leaves an empty space.
        if (booleanProperty != null && booleanProperty.propertyType == SerializedPropertyType.Boolean && !booleanProperty.boolValue)
        {
            return 0f;
        }

        // If true, return the normal height (or the expanded height for lists/arrays).
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}