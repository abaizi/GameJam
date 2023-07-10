using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class InformationAttribute : PropertyAttribute
{
    public enum InformationType{
        None, Info, Warning, Error   
    }


    public string Message;
    public InformationType InfoType;
    public bool IsAfterProperty;


    public InformationAttribute(string message, InformationType infoType, bool isAfterProperty){
        this.Message = message;
        this.IsAfterProperty = isAfterProperty;

        if(infoType == InformationType.None) this.InfoType = (InformationType)UnityEditor.MessageType.None;
        else if(infoType == InformationType.Info) this.InfoType = (InformationType)UnityEditor.MessageType.Info;
        else if(infoType == InformationType.Warning) this.InfoType = (InformationType)UnityEditor.MessageType.Warning;
        else if(infoType == InformationType.Error) this.InfoType = (InformationType)UnityEditor.MessageType.Error;
    }
}



[CustomPropertyDrawer(typeof(InformationAttribute))]
public class InformationDrawer: PropertyDrawer 
{
    private const int spaceBeforeTheBox = 10;
    private const int spaceAfterTheBox = 5;
    private const int iconWidth = 55;

    private InformationAttribute infoAttribute => (InformationAttribute)attribute;

#if UNITY_EDITOR
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if(EnableHelpBox()){
            EditorStyles.helpBox.richText = true;
            if(!infoAttribute.IsAfterProperty){
                position.height = CalcBoxHeight(infoAttribute.Message);
                position.y += spaceBeforeTheBox;
                EditorGUI.HelpBox(position, infoAttribute.Message, (MessageType)infoAttribute.InfoType);

                position.y += position.height + spaceAfterTheBox;
                EditorGUI.PropertyField(position, property, label);
            }else{
                position.height = EditorGUI.GetPropertyHeight(property, label);
                EditorGUI.PropertyField(position, property, label, true);

                position.y += position.height + spaceBeforeTheBox;
                position.height = CalcBoxHeight(infoAttribute.Message);
                EditorGUI.HelpBox(position, infoAttribute.Message, (MessageType)infoAttribute.InfoType);
            }
        }else{
            EditorGUI.PropertyField(position, property, label);
        }
    }

#endif

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if(EnableHelpBox()){
            return EditorGUI.GetPropertyHeight(property) + CalcBoxHeight(infoAttribute.Message) + spaceAfterTheBox + spaceBeforeTheBox;
        }else{
            return base.GetPropertyHeight(property, label);
        }
    }


    private bool EnableHelpBox(){
        if(EditorPrefs.HasKey("ShowHelpInInspector") && EditorPrefs.GetBool("ShowHelpInInspector")){
            return true;
        }
        return false;
    }

    private float CalcBoxHeight(string message){
        GUIStyle style = new GUIStyle(EditorStyles.helpBox);
        style.richText = true;
        float height = style.CalcHeight(new GUIContent(message), EditorGUIUtility.currentViewWidth - iconWidth);
        return height;
    }
}

