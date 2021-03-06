using System;
using UnityEngine;

public sealed class SpanTest : MonoBehaviour
{
    public static void FillSpan(Span<int> span)
    {
        for (var i = 0; i < span.Length; i++) span[i] = i;
    }

    public static int ReadSpan(ReadOnlySpan<int> span)
      => span[span.Length - 1];

    void Start()
    {
        var span = (Span<int>)(stackalloc int[100]);
        FillSpan(span);
        Debug.Log($"The last element value is {ReadSpan(span)}.");
    }
}
