using UnityEngine;

namespace MBusterClone
{
    public class Money:SelectableObject
    {
        #region Fields
        public MoneyType moneyType;
        [Header("References")]
        public string shredTag = "Shred";
        public string stackTag = "Stack";

        public Vector3 stackOffset;
        public Vector3 shredOffset;

        [Header("Compopnents")]
        [SerializeField]
        private MeshRenderer moneyRenderer;
        [SerializeField]
        private MeshRenderer uvRenderer;
        [SerializeField]
        private MeshRenderer doodleRenderer;

        bool canShred;
        bool canTake;

        int shredMoneyParamId;
        int addMoneyParamId;
        #endregion

        #region Public Methods
        public override void Start()
        {
            base.Start();
            shredMoneyParamId = Animator.StringToHash("Shred");
            addMoneyParamId = Animator.StringToHash("AddMoney");

        }
        /// <summary>
        /// It is the method in which the money object is dropped.
        /// </summary>  
        public override void OnMouseUp()
        {
            if (isSelect)
            {
                isSelect = false;
                transform.position = startPos;
                AnimatorActivate();
                MoneyDrop();
            }
        }
        /// <summary>
        /// Checks the win status after the episode is completed.
        /// </summary>
        public void LevelComplete()
        {
            if (canTake)
                gm.isWon = moneyType.Equals(MoneyType.Reel);
            else if (canShred)
                gm.isWon = !moneyType.Equals(MoneyType.Reel);

            string text = gm.isWon ? "Nice!" : "Fail!";
            uýManager.SetText(text);
            gm.isGameOver = true;
            uýManager.Complete();
        }
        /// <summary>
        /// Sets the material in the money object.
        /// </summary>
        /// <param name="moneyType"></param>
        public void SetMoney(MoneyType moneyType)
        {
            this.moneyType = moneyType;
            GameManager.Instance.GetMaterial(this.moneyType, out Material moneyMaterial,out Material doodleMat, out Material uvMat);          
            moneyRenderer.material = moneyMaterial;
            doodleRenderer.material = doodleMat;
            uvRenderer.material = uvMat;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// It is used to interact with the money object.
        /// </summary>
        private void MoneyDrop()
        {
            if (canTake)
            {
                transform.position = stackOffset;
                animator.SetTrigger(addMoneyParamId);
                Stack.Instance.AddMoney();
            }
            else if (canShred)
            {
                transform.position = shredOffset;
                animator.SetTrigger(shredMoneyParamId);
                Shred.Instance.ShredMoney();
            }
        }
        private void OnAnimEvent()
        {
            gm.isStartGame = true;
        }
        private void OnInteractable()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (!gm.isStartGame || gm.isGameOver)
                return;

            if (other.CompareTag(shredTag) && !canShred)
            {
                canShred = true;
                uýManager.PlayAnim(UIState.Shred);
                uýManager.SetText("Shred");

            }
            else if (other.CompareTag(stackTag) && !canTake)
            {
                canTake = true;
                uýManager.PlayAnim(UIState.Take);
                uýManager.SetText("Take");
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (!gm.isStartGame || gm.isGameOver)
                return;

            if (other.CompareTag(shredTag) && canShred)
                canShred = false;
            else if (other.CompareTag(stackTag) && canTake)
                canTake = false;
        }
        #endregion
    }

    public enum MoneyType
    {
        Reel,
        Fake,
        Doodle
    }
}

