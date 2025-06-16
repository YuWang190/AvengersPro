using UnityEngine;

namespace JW
{
    public interface IMainBridge
    {
        GameObject MainBridge { get; }
        void InitBridge(GameObject bridge);
        void SendToMain<T>(string methodName, T msg);
        void SendToMain(string methodName);
        void Toast(string toast);
    }
}
