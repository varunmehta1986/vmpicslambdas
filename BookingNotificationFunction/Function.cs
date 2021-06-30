using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using BookingNotificationFunction.Models;
using System.Text.Json;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BookingNotificationFunction
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public HttpStatusCode FunctionHandler(BookingRequest bookingRequest, ILambdaContext context)
        {
            //var accessKeyId = "AKIAYJ5XCCID5GBP2F44";
            //var secretAccessKey = "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";

            var awsSNSClient = new AmazonSimpleNotificationServiceClient("AKIAYJ5XCCID5GBP2F44",
                                    "SBYrHzz5FWYKBEU4FO1jz8DWQ4aF3PJt5WKEVgIC", Amazon.RegionEndpoint.APSoutheast2);
            var publishRequest = new PublishRequest()
            {
                TopicArn = "arn:aws:sns:ap-southeast-2:571077693959:BookingNotifications",
                Subject = "You have a new booking request",
                Message = "Name : " + bookingRequest.Name + Environment.NewLine
                           + "Email : " + bookingRequest.EmailId + Environment.NewLine
                           + "Phone : " + bookingRequest.Phone + Environment.NewLine
                           + "Description : " + bookingRequest.Description
            };
            var response = awsSNSClient.PublishAsync(publishRequest);
            return response.Result.HttpStatusCode;

        }
    }
}
