using System;
using Xunit;
using Branch.Clients.Json;
using System.Threading.Tasks;
using Branch.Clients.Json.Models;
using System.Collections.Generic;

namespace Branch.Tests.Clients.JsonTests
{
	public class OptionTests
	{

		[Fact]
		public void RespectOptions()
		{
			var options = new Options
			{
				Headers = new Dictionary<string, string>
				{
					{"X-Test-Header", "testing"},
					{"Content-Type", "application/json"},
				},
				Timeout = TimeSpan.FromMilliseconds(2500),
			};

			var client = new JsonClient("https://example.com", options);

			Assert.Equal(client.Options.Timeout, options.Timeout);
			Assert.Equal(client.Options.Headers, options.Headers);
		}
	}
}