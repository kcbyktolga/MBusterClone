using UnityEngine;

namespace MBusterClone
{
    public class Shred : InteractableObject<Shred>
    {
        #region Fields 
        int shredParamId;
        #endregion

        #region Private Methods
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            shredParamId = Animator.StringToHash("MoneyShredStart");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Invokes the fragmentation animation.
        /// </summary>
        public void ShredMoney()
        {
            PlayAnim(ref shredParamId);
        }
        #endregion

    }
}

