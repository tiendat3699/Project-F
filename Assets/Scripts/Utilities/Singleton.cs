using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// This is basic singleton. This will destroy any new
    /// versions created, leaving the original instance intact
    /// </summary>
    /// <typeparam name="T">Type of object you want to use singleton</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T: Component
    {
        protected static T _instance;
        public static T Instance {
            get {
                if(_instance == null) {
                    _instance = FindObjectOfType<T>();
                    if(_instance ==  null) {
                        GameObject obj = new(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }


        protected virtual void Awake() {
            if(_instance != null && _instance != this) {
                Destroy(this);
            } else {
                _instance = this as T;
            }
        }

    }
    
    /// <summary>
    /// Persistent version of the singleton. This will survive through scene
    /// loads. Perfect for system classes which require stateful, persistent data. Or audio sources
    /// where music plays through loading screens, etc
    /// </summary>
    /// <typeparam name="T">Type of object you want to use singleton</typeparam>
    public abstract class PersistentSingleton<T> : Singleton<T> where T : Component
    {
        protected override void Awake()
        {
            base.Awake();
            if(_instance == this) {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}