using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using GalleryJsonLambdaFunction;

namespace GalleryJsonLambdaFunction.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestMaternity()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
             function.CreateAndSaveJsonForGallery(new Models.PortfolioRequest()
            {
                BucketName = "vmpics-images",
                AlbumName = "maternity"
            });
        }
        [Fact]
        public void TestFamily()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            function.CreateAndSaveJsonForGallery(new Models.PortfolioRequest()
            {
                BucketName = "vmpics-images",
                AlbumName = "family"
            });
        }
        [Fact]
        public void TestEvent()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            function.CreateAndSaveJsonForGallery(new Models.PortfolioRequest()
            {
                BucketName = "vmpics-images",
                AlbumName = "event"
            });
        }
    }
}
