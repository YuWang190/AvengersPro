using UnityEngine;

namespace JW
{
    public abstract class BaseUI :  IUI
    {
        public abstract int TypeID { get; }
        public GameObject gameObject { get; private set; }
        public Transform transform { get; private set; }
        public bool isShow { get; private set; }
        private bool mIsFirstShow;
        public BaseUI(Transform transform)
        {
            this.transform = transform;
            gameObject = transform.gameObject;
            gameObject.SetActive(false);
            Init();
        }
        public virtual void Init()
        {

        }
        public virtual void Hide()
        {
            isShow = false;
            gameObject.SetActive(false);
        }
        public virtual void Show()
        {
            isShow = true;
            gameObject.SetActive(true);
            if (!mIsFirstShow) 
            {
                mIsFirstShow = true;
                FirstShow();
            }
        }
        public virtual void Update()
        {
        }

        public virtual void OnDestory()
        {
           
        }

        public virtual void ForceUpdate()
        {
           
        }

        public virtual void FirstShow()
        {
           
        }
    }
}
