using UnityEngine;

namespace MBusterClone
{
    public class GameManager : Singleton<GameManager>
    {
        #region Fields
        [Header("Checks")]
        public bool isStartGame;
        public bool isGameOver;
        public bool isWon;
        [Space(20)]
        [Header("Data")]
        [SerializeField]
        private Money money;
        [SerializeField]
        private LevelData levelData;
        [Space(20)]
        [Header("Materials")]
        [SerializeField]
        private Material uvFake;
        [SerializeField]
        private Material uvReel;
        [SerializeField]
        private Material doodle;
        [SerializeField]
        private Material moneyMat;

        public int Level
        {
            get
            {
                return Level = PlayerPrefs.GetInt("Level");
            }
            set
            {
                int level = value > levelData.levelList.Count-1 ? levelData.levelList.Count - 1 : value;
                PlayerPrefs.SetInt("Level", level);
            }
        }
        public int Score
        {
            get
            {
                return Score = PlayerPrefs.GetInt("Record");
            }
            set
            {
                PlayerPrefs.SetInt("Record", value);
            }
        }

        #endregion

        #region Private Methods
        private void Start()
        {
            SetLevel();
        }

        /// <summary>
        /// It is used to set the material of the money object.
        /// </summary>
        private void SetLevel()
        {      
            isGameOver = false;
            money.SetMoney(levelData.levelList[Level].type);
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Returns material based on money type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public void GetMaterial(MoneyType type, out Material money,out Material doodle, out Material uv)
        {
            money = moneyMat;

            switch (type)
            {
                default:
                case MoneyType.Reel:
                    doodle = moneyMat;
                    uv = uvReel;
                    break;
                case MoneyType.Fake:
                    doodle = moneyMat;
                    uv = uvFake;
                    break;
                case MoneyType.Doodle:
                    uv = uvReel;
                    doodle = this.doodle;
                    break;             
            }
        }

        /// <summary>
        /// Used to add score.
        /// </summary>
        /// <param name="amount"></param>
        public void AddScore(int amount)
        {
            int score = Score;
            score += amount;
            Score = score;
        }
        /// <summary>
        /// Used to save level.
        /// </summary>
        public void SaveLevel()
        {
            int level = Level;
            level += 1;
            Level = level;
        }
      
        #endregion

    }

}
