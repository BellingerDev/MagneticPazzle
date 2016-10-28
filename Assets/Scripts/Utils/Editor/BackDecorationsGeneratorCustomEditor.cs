using UnityEditor;
using UnityEngine;
using Utils;


[CustomEditor(typeof(BackDecorationsGenerator))]
public class BackDecorationsGeneratorCustomEditor : Editor
{
    private BackDecorationsGenerator generator;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        generator = target as BackDecorationsGenerator;

        EditorGUILayout.BeginVertical();
        {
            if (GUILayout.Button("Generate"))
            {
                generator.Generate();
            }

            if (GUILayout.Button("Clear"))
            {
                generator.Clear();
            }
        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}