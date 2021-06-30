using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.S3;
using AWSSecretManager;
using VMPicsLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace VMPicsLambda
{
    public class Function
    {

		/// <summary>
		/// A simple function that takes a string and returns both the upper and lower case version of the string.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public IEnumerable<PortfolioImage> FunctionHandler(PortfolioRequest portfolioRequest, ILambdaContext context)
		{
			var (accessKeyId, secretAccessKey) = SecretManager.GetSecret();

			var awsS3Client = new AmazonS3Client(accessKeyId, secretAccessKey, Amazon.RegionEndpoint.APSoutheast2);
			var images = awsS3Client.ListObjectsAsync(portfolioRequest.BucketName, $"{portfolioRequest.AlbumName}").Result;
			var files = images.S3Objects.Select(x => x.Key).Where(x => x != (portfolioRequest.AlbumName + "/"));
			var list = new ConcurrentBag<PortfolioImage>();
			Parallel.ForEach(files, image =>
			{
				list.Add(new PortfolioImage($"https://vmpics-images.s3-ap-southeast-2.amazonaws.com/" + image));
			});
			return list;
		}
	}
}
