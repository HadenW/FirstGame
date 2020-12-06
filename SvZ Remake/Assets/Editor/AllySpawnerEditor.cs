using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AllySpawner))]
public class AllySpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AllySpawner myScript = (AllySpawner)target;
        if (GUILayout.Button("Update Buttons"))
        {
            myScript.UpdateButtons();
        }
    }
}
