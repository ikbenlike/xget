using System.Net;
using System;
using System.Collections.Generic;

class wClient
{
	public static void Main(string[] args)
	{
		String[] arguments = Environment.GetCommandLineArgs();
		WebClient webClient = new WebClient();
		webClient.DownloadFile(arguments[1], arguments[2]);
		Console.WriteLine ("File to download:");
		Console.WriteLine(arguments[1]);
		Console.WriteLine ("Destination for file:");
		Console.WriteLine (arguments [2]);

	}
}