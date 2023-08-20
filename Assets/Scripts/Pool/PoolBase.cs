using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class PoolBase<T>  where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly ObjectPool<T> _pool;
        
        public PoolBase(T prefab, int defaultCapacity = 10, int max = 100, bool collectionCheck = false)
        {
            _prefab = prefab;
            _pool = new ObjectPool<T>(CreateFunc, GetFunc, ReleaseFunc, DestroySetup, collectionCheck, defaultCapacity, max);
        }
        
        /// <summary>
        /// Get object from pool
        /// </summary>
        /// <returns>Object from pool</returns>
        public T Spawn()
        {
            return _pool.Get();
        }
        
        /// <summary>
        /// Get object from pool with a given position and rotation
        /// </summary>
        /// <param name="position">Position to place the object</param>
        /// <param name="rotation">Rotation of object</param>
        /// <returns>Object from pool</returns>
        public T Spawn(Vector2 position, Quaternion rotation)
        {
            T obj = _pool.Get();
            obj.transform.SetPositionAndRotation(position, rotation);
            return obj;
        }
        
        /// <summary>
        /// Deactivate the object and release it back to the pool
        /// </summary>
        /// <param name="obj">object to release</param>
        public void Release(T obj)
        {
            _pool.Release(obj);
        }

        private void DestroySetup(T obj)
        {
            Object.Destroy(obj);
        }

        private void ReleaseFunc(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void GetFunc(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        private T CreateFunc()
        {
            return Object.Instantiate(_prefab);
        }
    }
}