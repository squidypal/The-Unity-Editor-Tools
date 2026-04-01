using UnityEngine;

namespace Util
{
    public static class DebugUtils
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Log(string msg) => Debug.Log(msg);

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void DrawLine(Vector3 a, Vector3 b, Color c, float d) => Debug.DrawLine(a, b, c, d);

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void DrawRay(Vector3 o, Vector3 dir, Color c, float d) => Debug.DrawRay(o, dir, c, d);
    }
}