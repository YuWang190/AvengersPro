[System.Serializable]
public class UserDataResponseJsonData : ResponseJsonBase
{
    public UserDataResponseData data;
}
[System.Serializable]
public class UserDataResponseData
{
    public int userId;
    public string nickname;
    public string avatarUrl;
    public string openid;
    public int createdAt;
    public string scenicSign;
}
