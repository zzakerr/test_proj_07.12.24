using UnityEngine;

[DisallowMultipleComponent]
public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected void Init()
    {
        if (Instance != null)
        {
            Debug.LogWarning("MonoSingleton: object of type already exists, instance will be destroyed = " + typeof(T).Name);
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
    }
}
