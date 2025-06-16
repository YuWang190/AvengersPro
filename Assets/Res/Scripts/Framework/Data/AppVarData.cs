using UnityEngine;
using YFramework;

public static class AppVarData
{
    public const ChannelEnum channelEnum = ChannelEnum.Test;
    public static string OpenID = "oYqTt68eKbXUbwY_e8tD1hUJIRiA";
    public static string Token ;
    public static string userName;//用户名
    public static string headURL;//头像地址
    private static Camera mMainCamera;
    /// <summary>
    ///主相机
    /// </summary>
    public static Camera mainCamera
    { 
        get
        {
            if (mMainCamera == null) {
                mMainCamera = Camera.main;
            }
            return mMainCamera;
        }
    }
    /// <summary>
    /// 游戏是否初始化完成了
    /// </summary>
    public static bool IsInit
    {
        get
        {
            return
                   !AppVarData.Token.IsNullOrEmpty()
                ;
        }
    }
}
