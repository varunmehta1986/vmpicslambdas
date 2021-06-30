using System;
using System.Collections.Generic;
using System.Text;

namespace BookingNotificationFunction.Models
{
	public class BookingRequest
	{
		public string Name { get; set; }
		public string EmailId { get; set; }
		public string Phone { get; set; }
		public string Description { get; set; }
	}
}
