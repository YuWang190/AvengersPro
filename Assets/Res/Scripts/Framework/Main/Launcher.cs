using UnityEngine;
using YFramework;

namespace JW
{
    public class Launcher : MonoBehaviour
    {
        void Start()
        {
            HttpModule.PostData<LoginResponseJsonData>(HttpConstData.Common_Login, new LoginJsonData() { openid = AppVarData.OpenID }, GetLoginInfo, (error) => { });
        }
        private void GetLoginInfo(LoginResponseJsonData data)
        {
            AppVarData.Token = data.data.token;
            BoardCastModule.Broadcast(CommonBoardcastData.GetToken);
        }
    }

}