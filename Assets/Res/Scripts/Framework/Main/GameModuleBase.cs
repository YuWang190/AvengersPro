using UnityEngine;

namespace JW
{
    public abstract class GameModuleBase: UnityEngine.MonoBehaviour , IMainBridge
    {
        public static GameModuleBase Instance { get; protected set; }
        public GameObject MainBridge { get; protected set; }
        public  void InitBridge(GameObject bridge) 
        {
            MainBridge = bridge;
        }
        public  void SendToMain<T>(string methodName, T msg) 
        {
            if (MainBridge == null)
            {
                Debug.LogError("MainBridge is null");
                return;
            }
            MainBridge.SendMessage(methodName, msg, SendMessageOptions.DontRequireReceiver);
        }
        public  void SendToMain(string methodName) {
            if (MainBridge == null)
            {
                Debug.LogError("MainBridge is null");
                return;
            }
            MainBridge.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
        }
        public void Toast(string toast) 
        {
            SendToMain("Toast", toast);
        }
    }
}
