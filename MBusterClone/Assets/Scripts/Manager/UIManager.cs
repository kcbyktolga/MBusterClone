using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MBusterClone
{
    public class UIManager : Singleton<UIManager>
    {
        #region Fields
        [Header("Components")]
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private TMP_Text levelText;
        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private TMP_Text infoText;
        [SerializeField]
        private TMP_Text scoreTextPopup;
        [SerializeField]
        private Button restartButton;

        GameManager gm;

        int shredParamId;
        int takeParamId;
        int completeParamId;
        int gameOverParamId;
        int idleParamId;
        int isWonParamId;
        int popupParamId;
        #endregion     

        #region Public Methods
        /// <summary>
        /// Plays state-dependent animations.
        /// </summary>
        /// <param name="state"></param>
        public void PlayAnim(UIState state)
        {
            animator.SetTrigger(GetParamId(state));
        }
        /// <summary>
        /// The endgame sets the score and creates the preliminary for animation.
        /// </summary>
        public void ScoreTextPopup()
        {
            int amount = gm.isWon ? 10 : -10;
            Color color = gm.isWon ? Color.green : Color.red;
            scoreTextPopup.color = color;
            scoreTextPopup.text = amount.ToString();
            animator.SetTrigger(popupParamId);
            gm.AddScore(amount);

        }
        /// <summary>
        /// Loads the new scene.
        /// </summary>
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /// <summary>
        /// Starts the level complete animation.
        /// </summary>
        public void Complete()
        {
            Stack.Instance.CompleteLevel();
            animator.SetBool(gameOverParamId, gm.isGameOver);
            animator.SetBool(isWonParamId, gm.isWon);
            animator.SetTrigger(completeParamId);
        }

        /// <summary>
        /// Sets the notification text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            infoText.text = text;
        }
        #endregion

        #region Private Methods
        private void Start()
        {
            gm = GameManager.Instance;

            shredParamId = Animator.StringToHash("Shred");
            takeParamId = Animator.StringToHash("Take");
            completeParamId = Animator.StringToHash("Complete");
            gameOverParamId = Animator.StringToHash("isGameOver");
            idleParamId = Animator.StringToHash("Idle");
            isWonParamId = Animator.StringToHash("isWon");
            popupParamId = Animator.StringToHash("Popup");

            levelText.text = $"Level {gm.Level+1}";
            scoreText.text = $"{gm.Score}";
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(Restart);
        }
        /// <summary>
        /// Returns the id of the animation to be played depending on the state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private int GetParamId(UIState state)
        {
            switch (state)
            {
                default:
                case UIState.Shred:
                    return shredParamId;
                case UIState.Take:
                    return takeParamId;
                case UIState.Idle:
                    return idleParamId;
                case UIState.Complete:
                    return completeParamId;
            }
        }       
        #endregion

    }

    public enum UIState
    {
        Shred,
        Take,
        Complete,
        Idle
    }
}

