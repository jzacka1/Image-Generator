using System;
using Xunit;
using APIReader.SplashBaseService;
using APIReader.Models;
using System.Collections.Generic;

namespace XUnitTestProject1
{
	public class UnitTest1
	{
		private SplashBaseService _splashBaseService;

		public UnitTest1()
		{
			_splashBaseService = new SplashBaseService();
		}

		[Fact]
		public void SplashService_GetImagesBySearch()
		{
			SplashImages splashImages = _splashBaseService.GetImagesBySearch("Laptop");

			Assert.NotEmpty(splashImages.images);
		}

		[Fact]
		public void SplashService_GetImagesByID()
		{
			SplashImage splashImage = _splashBaseService.GetImageByID(1);

			Assert.NotEmpty(splashImage.url);
		}
	}
}
