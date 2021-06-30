using Amazon.Lambda.Core;

namespace GalleryJsonLambdaFunction.Models
{
	public class PortfolioRequest
	{
		public string BucketName { get; set; }
		public string AlbumName { get; set; }
	}
}
