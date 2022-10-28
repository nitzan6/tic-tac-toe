using System;
using TicTacToe.GameManagement.Players;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ForceInterfaceAttribute))]
public class ForceInterfacePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // check if the property is an object reference type
        if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            ForceInterfaceAttribute forceAttribute = (ForceInterfaceAttribute)attribute;
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();
            UnityEngine.Object obj = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(UnityEngine.Object), allowSceneObjects: true);

            //only check the object if a change has been made in the object field
            if (EditorGUI.EndChangeCheck())
            {
                Debug.Log(forceAttribute.InterfaceType.IsAssignableFrom(obj.GetType()));


                if (obj == null)
                {
                    property.objectReferenceValue = null;
                }
                //In this case the assigned object is an instance of a class which implements the interface
                else if (forceAttribute.InterfaceType.IsAssignableFrom(obj.GetType()))
                {
                    property.objectReferenceValue = obj;
                }
                //if the assigned object is a gameobject, look for the component which implements the interface
                else if (obj is GameObject gameObject)
                {
                    MonoBehaviour component = (MonoBehaviour)gameObject.GetComponent(forceAttribute.InterfaceType);

                    if (component != null)
                    {
                        property.objectReferenceValue = component;
                    }
                }
                else if (obj is MonoScript monoScript)
                {
                    Type player = monoScript.GetClass();
                    Debug.Log(player);
                }

                EditorGUI.EndProperty();
            }
        }
        else
        {
            EditorGUI.LabelField(position, "Use ForceInterface on Objects");
        }
    }
}
