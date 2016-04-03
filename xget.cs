using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;

class wClient
{
	public static void Main(string[] args)
	{
		try {
			String[] arguments = Environment.GetCommandLineArgs();
			WebClient webClient = new WebClient();

			if (arguments[1] == "-f") {
				try
				{
					string[] listLinksToDownload = System.IO.File.ReadAllLines(arguments[2]);
					foreach (string linkToDownload in listLinksToDownload)
					{
						try {
							char[] splitChars = { '/' };
							string[] fileDest = linkToDownload.Split (splitChars);
							Console.WriteLine ("File to download:\n" + linkToDownload + "\nDestination:\n" + fileDest.Last());
							webClient.DownloadFile (linkToDownload, fileDest.Last());	
						} catch (IndexOutOfRangeException) {
							Console.WriteLine ("please input a valid link");
						}
					}

				}
				catch (System.IO.FileNotFoundException){
					Console.WriteLine ("please provide a valid path");
				}
			} else if (arguments[1] == "-l") {
				try {
					if (arguments[3] == "-o"){
						try {
							Console.WriteLine ("File to download:\n" + arguments [2] + "\nDestination:\n" + arguments [4]);
							webClient.DownloadFile (arguments [2], arguments [4]);	
						} catch (IndexOutOfRangeException) {
							Console.WriteLine("please input a valid path");
						}
					} 
				}
				catch (IndexOutOfRangeException) {
						try {
							char[] splitChars = { '/' };
							string linkToDownload = arguments [2];
							string[] fileDest = linkToDownload.Split (splitChars);
							Console.WriteLine ("File to download:\n" + arguments [2] + "\nDestination:\n" + fileDest.Last ());
							webClient.DownloadFile (arguments [2], fileDest.Last ());
						} catch (IndexOutOfRangeException) {
							Console.WriteLine ("please input a valid URL and/or destination");
							throw;
						}
					}
				} else if (arguments[1] == "-h") { 
					Console.WriteLine("xget is a simple file downloader");
					Console.WriteLine("use `xget -f [filename]` (without the brackets) to get links from the specified file");
					Console.WriteLine("use `xget -l [url] -o [destination]` to download a file from the specified url to the specified destination");
					Console.WriteLine("if no destination is provided it downloads to the folder the executable is in. It will extract");
					Console.WriteLine("a filename from the url. Example: `xget site.com/example.txt` will download to the directory of the executable");
					Console.WriteLine("and the file will be called `example.txt`");
				} else {
					Console.WriteLine ("xget is a simple file downloader");
					Console.WriteLine ("use `xget -f [filename]` (without the brackets) to get links from the specified file");
					Console.WriteLine ("use `xget -l [url] -o [destination]` to download a file from the specified url to the specified destination");
					Console.WriteLine ("if no destination is provided it downloads to the folder the executable is in. It will extract");
					Console.WriteLine ("a filename from the url. Example: `xget site.com/example.txt` will download to the directory of the executable");
					Console.WriteLine ("and the file will be called `example.txt`");
				}
		} catch (IndexOutOfRangeException){
			Console.WriteLine ("xget is a simple file downloader");
			Console.WriteLine ("use `xget -f [filename]` (without the brackets) to get links from the specified file");
			Console.WriteLine ("use `xget -l [url] -o [destination]` to download a file from the specified url to the specified destination");
			Console.WriteLine ("if no destination is provided it downloads to the folder the executable is in. It will extract");
			Console.WriteLine ("a filename from the url. Example: `xget site.com/example.txt` will download to the directory of the executable");
			Console.WriteLine ("and the file will be called `example.txt`");
		}
	}
}