using System.Net;

namespace GalleryJsonLambdaFunction.Models
{
	public class PortfolioImage
	{
		public string src { get; set; }
		public int width { get; }
		public int height { get; }
		public PortfolioImage(string imageUrl)
		{
			src = imageUrl;
			var img = System.Drawing.Image.FromStream(WebRequest.Create(imageUrl).GetResponse().GetResponseStream());
			if (img.Width > img.Height)
			{
				width = 3;
				height = 2;
			}
			else
			{
				width = 2;
				height = 3;
			}
		}
	}
}
