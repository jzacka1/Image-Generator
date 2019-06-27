using System;
using RestSharp;

namespace APIReader
{
	public abstract class APIReader : RestClient
	{
		public APIReader(string url) {
			BaseUrl = new Uri(url);
		}

		public override IRestResponse Execute(IRestRequest request)
		{
			var response = base.Execute(request);
			return response;
		}

		//public T Get<T>(IRestRequest request) where T : new(){
		
		//}
	}
}
