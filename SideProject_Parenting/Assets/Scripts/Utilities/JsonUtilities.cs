using UnityEngine;

namespace Parenting.Scripts.Utilities
{
    public class JsonUtilities
    {
        public static object SerializeToObject<T>(T instance)
        {
            return JsonUtility.ToJson(instance);
        }

        public static T DeserializeFromObject<T>(object obj)
        {
            if (obj is string json)
                return JsonUtility.FromJson<T>(json);

            Debug.LogWarning("Object is not a JSON string");
            return default;
        }
    }
}
