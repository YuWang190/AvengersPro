using UnityEngine;

namespace JW
{
    public abstract class BasePanel : BaseUI, IPanel
    {
        public BasePanel(Transform transform) : base(transform)
        {

        }
    }
}
