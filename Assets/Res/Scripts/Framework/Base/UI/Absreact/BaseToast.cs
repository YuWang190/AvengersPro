using UnityEngine;

namespace JW
{
    public abstract class BaseToast : BaseUI, IToast
    {
        public BaseToast(Transform transform) : base(transform)
        {

        }
    }
}
