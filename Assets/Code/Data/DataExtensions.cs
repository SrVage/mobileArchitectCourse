using UnityEngine;

namespace Code.Data
{
    public static class DataExtensions
    {
        public static Vector3Data ConvertToVector3Data(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 ConvertToVector3(this Vector3Data vector) => 
            new Vector3(vector.X, vector.Y, vector.Z);

        public static string ConvertFromJson(this object obj) => JsonUtility.ToJson(obj);
        public static T ConvertJson<T>(this string json) => JsonUtility.FromJson<T>(json);
    }
}