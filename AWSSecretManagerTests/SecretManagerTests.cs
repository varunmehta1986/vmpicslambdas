using AWSSecretManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSSecretManagerTests
{

	[TestClass]

	public class SecretManagerTests
	{
		[TestMethod]
		public void GetSecretTest()
		{
			var result = SecretManager.GetSecret();
		}
	}
}
