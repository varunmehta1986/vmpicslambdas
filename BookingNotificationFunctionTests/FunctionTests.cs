using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingNotificationFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingNotificationFunction.Models;

namespace BookingNotificationFunction.Tests
{
	[TestClass()]
	public class FunctionTests
	{
		[TestMethod()]
		public void FunctionHandlerTest()
		{
			var bookingRequest = new BookingRequest();
			bookingRequest.Description = "test";
			bookingRequest.EmailId = "vmtest@test.com";
			bookingRequest.Name = "VarunTest";
			bookingRequest.Phone = "23232323";
			var response = new Function().SendBookingNotification(bookingRequest);

		}
	}
}