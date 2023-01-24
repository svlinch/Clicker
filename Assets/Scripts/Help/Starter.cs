using System.Collections;
using UnityEngine;

public abstract class Starter : MonoBehaviour
{
    public abstract IEnumerator Initialize();
}

public abstract class SingletonStarter<T>: Starter where T: Component
{
    public static T Instance;
    protected virtual void Awake()
    {
        Instance = this as T;
    }
}
