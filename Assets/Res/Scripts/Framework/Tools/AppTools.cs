using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JW
{
    public static class AppTools
    {
        public static void Toast<T>(T t) 
        {
            if (t == null) return;
#if UNITY_EDITOR
            Debug.Log(t.ToString());
#else
              GameModuleBase.Instance.Toast(t.ToString());
#endif
        }
        /// <summary>
        /// 获取我的信息
        /// </summary>
        /// <param name="callBack"></param>
        public static void GetMyData(Action<UserDataResponseJsonData> callBack)
        {
            HttpModule.GetData<UserDataResponseJsonData>(HttpConstData.Common_MyInfo, callBack,(error)=> { });
        }
        /// <summary>
        /// 是否在UI上
        /// </summary>
        /// <returns></returns>
        public static bool IsOnUI()
        {
            //判断点击是否触控在UI上的方法
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {

                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            return false;
        }
    }
}
