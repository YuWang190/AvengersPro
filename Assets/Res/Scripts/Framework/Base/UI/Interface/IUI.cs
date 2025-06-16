using UnityEngine;

namespace JW
{
    /// <summary>
    /// UI»ùÀà
    /// </summary>
    public interface IUI
    {
        GameObject gameObject { get; }
        Transform transform { get; }
        int TypeID { get; }
        bool isShow { get; }
        void Init();
        void Show();
        void Hide();
        void Update();
        void OnDestory();
        void ForceUpdate();
        void FirstShow();
    }
}