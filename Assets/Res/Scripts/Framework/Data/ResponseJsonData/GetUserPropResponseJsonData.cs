namespace JW
{
    [System.Serializable]
    public class GetUserPropResponseJsonData : ResponseJsonBase
    {
        public GetUserPropResponseData[] data;
    }
    [System.Serializable]
    public class GetUserPropResponseData
    {
        public string propCode;
        public int quantity;
        public string gameCode;
        public string scenicSign;
    }
}
