﻿using Microsoft.Azure.WebJobs;
using System;
using System.Configuration;
using System.Linq;

namespace TrakIMDB250.Scraper
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(string.Format("Connection strings: [{0}]",
				string.Join(", ",
					ConfigurationManager.ConnectionStrings
						.Cast<ConnectionStringSettings>()
						.Select(connectionString => connectionString.Name)))
				);

			var host = new JobHost();

			host.Call(typeof(Functions).GetMethod("ScrapeIMDB250"));
		}
	}
}
