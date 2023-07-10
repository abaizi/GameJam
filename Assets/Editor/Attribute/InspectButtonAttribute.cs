using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif


[System.AttributeUsage(System.AttributeTargets.Field)]
public class InspectButtonAttribute : PropertyAttribute
{
    public readonly string methodName;

    public InspectButtonAttribute(string methodName){
        this.methodName = methodName;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(InspectButtonAttribute))]
public class InspectButtonAttributeDrawer : PropertyDrawer {

    private InspectButtonAttribute buttonAttribute => (InspectButtonAttribute)attribute;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        GUI.skin.button.alignment = TextAnchor.MiddleLeft;
        
        if(GUI.Button(position, buttonAttribute.methodName)){
            System.Type type = property.serializedObject.targetObject.GetType();
            MethodInfo methodInfo = type.GetMethod(buttonAttribute.methodName,
                 BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if(methodInfo == null){
                Debug.LogWarning($"InspectButton: Unable to find method {buttonAttribute.methodName} in {type}");
            }else{
                methodInfo.Invoke(property.serializedObject.targetObject, null);
            }
        }
    }
}
#endif
