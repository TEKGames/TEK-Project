using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (CameraController))]
public class CameraControllerEditor : Editor {

    SerializedProperty invertCamera;
    SerializedProperty xSensitivity;
    SerializedProperty ySensitivity;

    private void OnEnable()
    {
        invertCamera = serializedObject.FindProperty("invertCamera");
        xSensitivity = serializedObject.FindProperty("xSensitivity");
        ySensitivity = serializedObject.FindProperty("ySensitivity");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        xSensitivity.floatValue = EditorGUILayout.Slider("Sensitivity X", xSensitivity.floatValue, 0.2f, 10f);
        ySensitivity.floatValue = EditorGUILayout.Slider("Sensitivity Y", ySensitivity.floatValue, 0.2f, 10f);
        EditorGUILayout.PropertyField(invertCamera);
        serializedObject.ApplyModifiedProperties();
    }
}
