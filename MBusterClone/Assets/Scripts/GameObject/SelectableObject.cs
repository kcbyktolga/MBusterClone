using UnityEngine;

namespace MBusterClone
{
    public class SelectableObject : MonoBehaviour
    {
        #region Fields
        [Header("Componenets")]
        public Animator animator;
        [HideInInspector]
        public Vector3 startPos;
        [HideInInspector]
        public bool isSelect;
    
        public GameManager gm;
        [HideInInspector]
        public UIManager uýManager;

        private Camera mainCamera;

        private Vector3 mouseOffset;  
        
        private float mouseCoordZ;

        private int holdParamId;
        private int dropParamId;
        #endregion

        #region Private Methods
        public virtual void Start()
        {
            gm = GameManager.Instance;
            uýManager = UIManager.Instance;

            mainCamera = GameObject.FindGameObjectWithTag("Primer Camera").GetComponent<Camera>();
            startPos = transform.position;

            holdParamId = Animator.StringToHash("Hold");
            dropParamId = Animator.StringToHash("Drop");
        }

        /// <summary>
        /// The method by which the object is selected.
        /// </summary>
        private void OnMouseDown()
        {
            if (!gm.isStartGame || gm.isGameOver)
                return;

            mouseCoordZ = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;

            // offset = gameobject world pos - mouse world pos
            mouseOffset = gameObject.transform.position - GetMouseWorldPos();

            if (!isSelect)
            {
                isSelect = true;
                PlayAnim(holdParamId);    
            }
        }
        /// <summary>
        /// It is the method in which the drop of the object takes place.
        /// </summary>
        public virtual void OnMouseUp()
        {
            if (!gm.isStartGame || gm.isGameOver)
                return;

            if (isSelect)
            {
                isSelect = false;
                transform.position = startPos;
                AnimatorActivate();
                PlayAnim(dropParamId);
            }
        }
        /// <summary>
        /// The method by which the object is moved.
        /// </summary>
        private void OnMouseDrag()
        {
            if (!gm.isStartGame || gm.isGameOver)
                return;

            transform.position = GetMouseWorldPos() + mouseOffset;
        }
        /// <summary>
        /// Returns the actual position of the mouse in the scene in Vector 3 type.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetMouseWorldPos()
        {
            // pixel coord(x,y)
            Vector3 mousePoint = Input.mousePosition;

            // z coord of gameobject on screen
            mousePoint.z = mouseCoordZ;
            Vector3 pos = mainCamera.ScreenToWorldPoint(mousePoint);

            return new Vector3(pos.x, transform.position.y, pos.z);
        }

        /// <summary>
        /// Plays the animation according to the relevant parameter.
        /// </summary>
        /// <param name="id"></param>
        public void PlayAnim(int id)
        {
            animator.SetTrigger(id);
        }

        /// <summary>
        /// Turns the animator component enable or disable after the animation plays.
        /// </summary>
        public void AnimatorActivate()
        {
            animator.enabled = !isSelect;
        }
        #endregion

        #region Virtual Methods
        //public virtual void HoldObject()
        //{
        //    // transform.position = new Vector3(transform.position.x,holdingHeight,transform.position.z);
        //    Vector3 holdPos = new Vector3(transform.position.x, holdingHeight, transform.position.z);

        //    transform.position = Vector3.Lerp(startPos,holdPos,duration);
        //    transform.rotation = Quaternion.Lerp(startQuaternion, holdQuaternion, duration);
        //}
        //public virtual void DropObject()
        //{
        //    //transform.position = startPos;
        //    transform.position = Vector3.Lerp(transform.position,startPos,duration);
        //    transform.rotation = Quaternion.Lerp(holdQuaternion, startQuaternion, duration);
        //}
        #endregion

    }

}

