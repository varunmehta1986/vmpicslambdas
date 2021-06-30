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
using AWSSecretManager;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BookingNotificationFunction
{
    public class Function
    {

        public HttpStatusCode SendBookingNotification(BookingRequest bookingRequest)
        {
            var (accessKeyId, secretAccessKey) = SecretManager.GetSecret();
            var awsSNSClient = new AmazonSimpleNotificationServiceClient(accessKeyId,
                                    secretAccessKey, Amazon.RegionEndpoint.APSoutheast2);
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
