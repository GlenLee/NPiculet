namespace NPiculet.Service.Weixin
{
	public class OJsSignature
	{
		public string NonceStr; //生成签名的随机串
		public long Timestamp; //生成签名的时间戳
		public string Signature; //生成的签名

		public string Need; //签名前的字符串
	}
}