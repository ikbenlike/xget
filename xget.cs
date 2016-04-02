using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;

class wClient
{
	public static void Main(string[] args)
	{
		String[] arguments = Environment.GetCommandLineArgs();
		WebClient webClient = new WebClient();

		try 
		{
			Console.WriteLine ("File to download:\n" + arguments [1] + "\nDestination:\n" + arguments [2]);
			webClient.DownloadFile(arguments[1], arguments[2]);	
		}

		catch (IndexOutOfRangeException) {
			try
			{
				char[] splitChars = { '/' };
				string linkToDownload = arguments[1];
				string[] fileDest = linkToDownload.Split(splitChars);
				Console.WriteLine("File to download:\n" + arguments[1] + "\nDestination:\n" + fileDest.Last());
				webClient.DownloadFile(arguments[1], fileDest.Last());
			}
			catch (IndexOutOfRangeException) {
				Console.WriteLine ("please input a valid URL and destination");
				throw;
			}
		}
	}
}