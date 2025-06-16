[System.Serializable]
public class CommonUseResponseJsonData : ResponseJsonBase
{
    public SendKongMingDengData data;
}

[System.Serializable]
public class SendKongMingDengData
{
    public string propCode;
    public string gameCode;
    public string scenicSign;
    public string usePropToken;
}
