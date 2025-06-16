namespace JW
{
    [System.Serializable]
    public class CommonPackageResponseJsonData : ResponseJsonBase
    {
        public CommonPackageResponseData[] data;
    }
    [System.Serializable]
    public class CommonPackageResponseData 
    {
        public string packageCode;
        public string scenicSign;
        public string name;
        public string icon;
        public int price;
        /// <summary>
        /// 优惠价格
        /// </summary>
        public int discountPrice;
        public string description;
        public string gameCode;

        public CommonPackageInnerData[] innerProps;
    }
    [System.Serializable]
    public class CommonPackageInnerData
    { 
        public string propCode;
        public int quantity;
        public string propName;
        public string icon;
        public string description;
        public int price;

    }
}
