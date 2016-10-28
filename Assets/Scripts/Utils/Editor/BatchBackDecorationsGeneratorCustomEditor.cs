using UnityEditor;
using UnityEngine;
using Utils;


[CustomEditor(typeof(BatchBackDecorationsGenerator))]
public class BatchBackDecorationsGeneratorCustomEditor : Editor
{
    private BatchBackDecorationsGenerator generator;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        generator = target as BatchBackDecorationsGenerator;

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