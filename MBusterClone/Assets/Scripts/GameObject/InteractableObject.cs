using UnityEngine;

namespace MBusterClone
{
    public class InteractableObject<T> : MonoBehaviour where T : InteractableObject<T>
    {
        #region Fields 
        [Header("Components")]
        public Animator animator;
        public Money money;
        public static T Instance;
        #endregion

        #region Private Methods
        /// <summary>
        /// Animation events..
        /// </summary>
        private void OnAnimEvent()
        {
            money.LevelComplete();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Plays the animation linked to the id.
        /// </summary>
        /// <param name="id"></param>
        public void PlayAnim(ref int id)
        {
            animator.SetTrigger(id);
        }
        #endregion

    }
}

