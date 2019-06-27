using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace ImageGenerator
{
	public class ImageGeneratorService
	{
		public string GetImageNameFromURL(string url){
			string pattern = @"([a-zA-Z0-9\s_\\.\-\(\):])+(.gif|.png|.jpg)$";
			Match result = Regex.Match(url, pattern);
			return result.Value;
		}
	}

	
}
