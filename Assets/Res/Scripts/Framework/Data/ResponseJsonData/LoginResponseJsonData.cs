[System.Serializable]
public class LoginResponseJsonData : ResponseJsonBase
{
    public LoginInfo data;
}
[System.Serializable]
public class LoginInfo {
    public string token;
    public string openid;
    public string mobile;
    public string scenicSign;
    public string nickname;
    public string avatarUrl;
}
