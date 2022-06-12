
//This script only runs in editor mode and it has access to the editor for the class type LowerPuzzleThreeManager

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LowerPuzzleThreeManager))]
public class LowerPuzzleThreeManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Adds a label to LowerPuzzleThreeManager in the inspector to describe what it does
        
        GUIStyle s = new GUIStyle(EditorStyles.label);
        s.fontSize = 14;
        s.alignment = TextAnchor.MiddleCenter;

        EditorGUILayout.LabelField("This object manages everything on Puzzle 3 of the lower region", s);
        EditorGUILayout.LabelField("", s);

        base.OnInspectorGUI();
    }
}

#endif
