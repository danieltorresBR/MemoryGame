using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T getInstance()
    {
        if (instance == null)
            instance = (T)FindObjectOfType(typeof(T));

        return instance;
    }

    void Start()
    {
        SingletonStart();
    }

    public bool SingletonStart()
    {
        if (instance && !instance.gameObject.Equals(gameObject))
        {
            Destroy(gameObject);

            return false;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            if (instance == null)
                instance = (T)FindObjectOfType(typeof(T));
            return true;
        }
    }
}