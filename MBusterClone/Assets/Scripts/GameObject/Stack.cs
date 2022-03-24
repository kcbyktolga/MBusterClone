using UnityEngine;

namespace MBusterClone
{
    public class Stack :InteractableObject<Stack>
    {
        #region Fields 
        public Vector3 animPos;
        int addMoneyParamId;
        int completeParamId;

        #endregion

        #region Private Methods
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            addMoneyParamId = Animator.StringToHash("AddMoney");
            completeParamId = Animator.StringToHash("LevelCompleted");
        }
        /// <summary>
        /// Pop up showing the score earned when the level is completed.
        /// </summary>
        private void ScorePopup()
        {
            UIManager.Instance.ScoreTextPopup();
        }
        /// <summary>
        /// It is used to pass the next level and refresh the stage.
        /// </summary>
        private void NextLevel()
        {
            GameManager.Instance.SaveLevel();
            UIManager.Instance.Restart();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds the dropped coin to the stack
        /// </summary>
        public void AddMoney()
        {
            PlayAnim(ref addMoneyParamId);
        }

        /// <summary>
        /// Animation shown when level is completed.
        /// </summary>
        public void CompleteLevel()
        {
            transform.position = animPos;
            transform.eulerAngles = new Vector3(0, 90, 0);
            PlayAnim(ref completeParamId);
        }
        #endregion
    }
}

