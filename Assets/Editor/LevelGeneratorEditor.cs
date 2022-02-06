using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var isDirty = false;
        if (GUILayout.Button("generate"))
        {
            ((LevelGenerator)target).GenerateLevel();
            isDirty = true;
        }
        if (GUILayout.Button("clear"))
        {
            ((LevelGenerator)target).ClearLevel();
            isDirty = true;
        }
        if (isDirty)
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
