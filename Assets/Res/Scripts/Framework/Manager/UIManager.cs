using System.Collections.Generic;
using UnityEngine;

namespace JW
{
    public class UIManager
    {
        public Transform transform { get; private set; }
        private IDictionary<int, IPanel> mPanelDict;
        private IDictionary<int, ITipUI> mTipUIDict;
        private IDictionary<int, IToast> mToastDict;
        public static UIManager Instance;
        public UIManager(Transform transform)
        {
            Instance = this;
            this.transform = transform;
            mPanelDict = new Dictionary<int, IPanel>();
            mTipUIDict = new Dictionary<int, ITipUI>();
            mToastDict = new Dictionary<int, IToast>();
        }
        /// <summary>
        /// 帧函数
        /// </summary>
        public void Update()
        {
            foreach (var item in mPanelDict)
            {
                item.Value.ForceUpdate();
                if (item.Value.isShow)
                    item.Value.Update();
            }
            foreach (var item in mTipUIDict)
            {
                item.Value.ForceUpdate();
                if (item.Value.isShow)
                    item.Value.Update();
            }
            foreach (var item in mToastDict)
            {
                item.Value.ForceUpdate();
                if (item.Value.isShow)
                    item.Value.Update();
            }
        }

        public void Ondestory()
        {
            foreach (var item in mPanelDict)
            {
                item.Value.OnDestory();
            }
            foreach (var item in mTipUIDict)
            {
                item.Value.OnDestory();
            }
            foreach (var item in mToastDict)
            {
                item.Value.OnDestory();
            }
        }

        /// <summary>
        /// 显示面板
        /// </summary>
        /// <param name="panelID"></param>
        public T ShowPanel<T>(int panelID) where T : class,IPanel
        {
            if (!mPanelDict.ContainsKey(panelID)) return default(T);
            IPanel panel = mPanelDict[panelID];
            panel.Show();
            return panel as T;
        }
        /// <summary>
        /// 显示面板
        /// </summary>
        /// <param name="panelID"></param>
        public void ShowPanel(int panelID)
        {
            if (!mPanelDict.ContainsKey(panelID)) return ;
            IPanel panel = mPanelDict[panelID];
            panel.Show();
        }

       

        /// <summary>
        /// 显示面板
        /// </summary>
        /// <param name="panelID"></param>
        public void HidePanel(int panelID)
        {
            if (!mPanelDict.ContainsKey(panelID)) return;
            mPanelDict[panelID].Hide();
        }
        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="toastID"></param>
        public T ShowToast<T>(int toastID) where T : class, IToast
        {
            if (!mToastDict.ContainsKey(toastID)) return default(T);
            IToast toast = mToastDict[toastID];
            toast.Show();
            return toast as T;
        }
        /// <summary>
        /// 隐藏提示
        /// </summary>
        /// <param name="id"></param>
        public void HideToast(int id)
        {
            if (!mToastDict.ContainsKey(id)) return;
            mToastDict[id].Hide();
        }
        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="tipID"></param>
        public T ShowTipUI<T>(int tipID) where T : class, ITipUI
        {
            if (!mTipUIDict.ContainsKey(tipID)) return default(T);
            ITipUI tipUI = mTipUIDict[tipID];
            tipUI.Show();
            return tipUI as T;
        }
        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="tipID"></param>
        public void ShowTipUI(int tipID)
        {
            if (!mTipUIDict.ContainsKey(tipID)) return;
            ITipUI tipUI = mTipUIDict[tipID];
            tipUI.Show();
        }
        /// <summary>
        /// 添加面板
        /// </summary>
        /// <param name="panel"></param>
        public void AddPanel(IPanel panel)
        {
            if (panel == null) return;
            if (!mPanelDict.ContainsKey(panel.TypeID))
            {
                mPanelDict.Add(panel.TypeID, panel);
            }
        }
        /// <summary>
        /// 添加提示UI
        /// </summary>
        /// <param name="panel"></param>
        public void AddTipUI(ITipUI tipUI)
        {
            if (tipUI == null) return;
            if (!mTipUIDict.ContainsKey(tipUI.TypeID))
            {
                mTipUIDict.Add(tipUI.TypeID, tipUI);
            }
        }
        /// <summary>
        /// 添加Toast
        /// </summary>
        /// <param name="panel"></param>
        public void AddToast(IToast toast)
        {
            if (toast == null) return;
            if (!mToastDict.ContainsKey(toast.TypeID))
            {
                mToastDict.Add(toast.TypeID, toast);
            }
        }
    }
}
