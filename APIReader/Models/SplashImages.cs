using System;
using System.Collections.Generic;
using System.Text;

namespace APIReader.Models
{

	public class SplashImages
	{
		public IEnumerable<SplashImage> images {get;set;}
	}

	public class SplashImage
	{
		public int id { get; set; }
		public string url { get; set; }
		public string large_url { get; set; }
		public int source_id { get; set; }
		public string copyright { get; set; }
		public string site { get; set; }
	}
}
