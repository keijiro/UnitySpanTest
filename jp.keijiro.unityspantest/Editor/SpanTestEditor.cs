using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpanTest))]
sealed class SpanTestEditor : Editor
{
#if NET_STANDARD_2_0 || NET_STANDARD_2_1

    public static int ReadSpan(ReadOnlySpan<int> span)
      => span[0];

#else

    public static int ReadSpan(ReadOnlySpan<int> span)
    {
        var temp = (Span<int>)(stackalloc int[span.Length]);
        span.CopyTo(temp);
        return temp[0];
    }

#endif

    public override void OnInspectorGUI()
    {
        var span = (Span<int>)(stackalloc int[100]);
        SpanTest.FillSpan(span);
        var text = $"The first element value is {ReadSpan(span)}.";
        EditorGUILayout.HelpBox(text, MessageType.None);
    }
}
