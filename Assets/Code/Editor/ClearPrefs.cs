using UnityEditor;
using UnityEngine;


public static class ClearPrefs
{
    [MenuItem("Tools/ClearPrefs")]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
