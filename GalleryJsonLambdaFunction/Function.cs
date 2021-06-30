using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using AWSSecretManager;
using GalleryJsonLambdaFunction.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace GalleryJsonLambdaFunction
{
	public class Function
	{

		public async void CreateAndSaveJsonForGallery(PortfolioRequest portfolioRequest)
		{
			var (accessKeyId, secretAccessKey) = SecretManager.GetSecret();

			var awsS3Client = new AmazonS3Client(accessKeyId, secretAccessKey, Amazon.RegionEndpoint.APSoutheast2);
			var images = awsS3Client.ListObjectsAsync(portfolioRequest.BucketName, $"{portfolioRequest.AlbumName}").Result;
			var files = images.S3Objects.Select(x => x.Key).Where(x => x != (portfolioRequest.AlbumName + "/"));
			var list = new List<PortfolioImage>();
			foreach (var image in files)
			{
				list.Add(new PortfolioImage($"https://vmpics-images.s3-ap-southeast-2.amazonaws.com/" + image));
			}
			var listToJson = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(list));
			var memoryStream = new MemoryStream(listToJson);
			var putObject = new PutObjectRequest()
			{
				BucketName = portfolioRequest.BucketName,
				Key = portfolioRequest.AlbumName + ".json",
				ContentType = "application/json",
				InputStream = memoryStream
				
			};
			var result = await awsS3Client.PutObjectAsync(putObject);
		}
	}
}
