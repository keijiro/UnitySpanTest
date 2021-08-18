using System;
using UnityEngine;

public sealed class SpanTest : MonoBehaviour
{
    public static void FillSpan(Span<int> span)
    {
        for (var i = 0; i < span.Length; i++) span[i] = i;
    }

#if NET_STANDARD_2_0 || NET_STANDARD_2_1

    public static int ReadSpan(ReadOnlySpan<int> span)
      => span[span.Length - 1];

#else

    public static int ReadSpan(ReadOnlySpan<int> span)
    {
        var temp = (Span<int>)(stackalloc int[span.Length]);
        span.CopyTo(temp);
        return temp[temp.Length - 1];
    }

#endif

    void Start()
    {
        var span = (Span<int>)(stackalloc int[100]);
        FillSpan(span);
        Debug.Log($"The last element value is {ReadSpan(span)}.");
    }
}
