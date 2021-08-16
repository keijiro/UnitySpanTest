using System;
using UnityEngine;

public sealed class SpanTest : MonoBehaviour
{
    void FillSpan(Span<int> span)
    {
        for (var i = 0; i < span.Length; i++) span[i] = i;
    }

    void Start()
    {
        var span = (Span<int>)(stackalloc int[100]);
        FillSpan(span);
        Debug.Log(span[span.Length - 1]);
    }
}
