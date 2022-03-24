using UnityEngine;

namespace MBusterClone
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        #region FÝelds
        private enum SingletonType
        {
            DontDestroy,
            Destroy
        }
        public static T Instance;
        [SerializeField]
        private SingletonType type;
        #endregion

        #region Virtual Methods
        public virtual void Awake()
        {
            if (type.Equals(SingletonType.DontDestroy))
            {
                if (Instance == null)
                {
                    Instance = GetComponent<T>();
                    DontDestroyOnLoad(this);
                }
                else
                {
                    Destroy(this);
                }
            }
            else
            {
                Instance = GetComponent<T>();
            }

        }
        #endregion
    }
}

