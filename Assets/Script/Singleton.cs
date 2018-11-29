using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<T>();
                singleton.name = typeof(T).ToString();
            }
            return instance;
        }
        set
        {
            if (instance == null)
            {
                DontDestroyOnLoad(value.gameObject);
                instance = value;
            }
            else
            {
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Instance = this as T;
        Init();
    }

    /// <summary>
    /// Allows each class inheriting from Singleton class to use the Awake function
    /// </summary>
    protected virtual void Init(){}
}