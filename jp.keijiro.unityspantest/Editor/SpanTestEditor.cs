using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpanTest))]
sealed class SpanTestEditor : Editor
{
    public static int ReadSpan(ReadOnlySpan<int> span)
      => span[0];

    public override void OnInspectorGUI()
    {
        var span = (Span<int>)(stackalloc int[100]);
        SpanTest.FillSpan(span);
        var text = $"The first element value is {ReadSpan(span)}.";
        EditorGUILayout.HelpBox(text, MessageType.None);
    }
}
