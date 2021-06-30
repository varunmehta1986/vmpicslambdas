using Amazon.Lambda.Core;

namespace VMPicsLambda.Models
{
	public class PortfolioRequest
	{
		public string BucketName { get; set; }
		public string AlbumName { get; set; }
	}
}
