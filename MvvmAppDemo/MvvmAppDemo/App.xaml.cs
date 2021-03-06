﻿using GalaSoft.MvvmLight.Ioc;
using MvvmAppDemo.ViewModel;
using Xamarin.Forms;

namespace MvvmAppDemo
{
	public partial class App : Application
	{
		//ViewModelLocator object to handle ViewModels and bindings between them and Views (Pages):
		private static ViewModelLocator _locator;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		public App()
		{
			InitializeComponent();
			// Setup navigation service:
			var navigationService = new NavigationService();
			// Configure pages:
			navigationService.Configure(AppPages.MainPage, typeof(MainPage));
			navigationService.Configure(AppPages.DetailsPage, typeof(DetailsPage));
			// Register NavigationService in IoC container:
			SimpleIoc.Default.Register<INavigationService>(() => navigationService);

			// Create new Navigation Page and set MainPage as its default page:
			var firstPage = new NavigationPage(new MainPage());
			// Set Navigation page as default page for Navigation Service:
			navigationService.Initialize(firstPage);
			// You have to also set MainPage property for the app:
			MainPage = firstPage;
		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
