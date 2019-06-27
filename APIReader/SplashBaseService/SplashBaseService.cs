using APIReader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIReader.SplashBaseService
{
	public class SplashBaseService : APIReader
	{
		public string baseURL { get; set; }

		protected readonly string ApiKey;

		public SplashBaseService()
			: base("http://www.splashbase.co/api/v1/")
		{
			this.baseURL = baseURL;
		}

		public SplashImages GetImagesBySearch(string search){
			string link = String.Format("images/search?query=>{0}", search);

			//Make request from API
			RestRequest request = new RestRequest(link, Method.GET);

			//Make response based on request
			var response = base.Execute<SplashImages>(request);

			//Check if the response is OK and returns data
			if(response.StatusCode == System.Net.HttpStatusCode.OK){
				return response.Data;
			}

			return default(SplashImages);
		}

		public SplashImage GetImageByID(int id)
		{
			string link = String.Format("images/{0}", id);

			//Make request from API
			RestRequest request = new RestRequest(link, Method.GET);

			//Make response based on request
			var response = base.Execute<SplashImage>(request);

			//Check if the response is OK and returns data
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return response.Data;
			}

			return default(SplashImage);
		}
	}
}
