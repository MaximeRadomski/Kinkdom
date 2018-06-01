using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Kinkdom.FakeData;
using Kinkdom.Models;
using Kinkdom.PageModels;
using Kinkdom.Pages;
using Kinkdom.Services;
using Kinkdom.Services.Interfaces;
using Kinkdom.Views;
using SQLite;
using Xamarin.Forms;

namespace Kinkdom
{
	public partial class App : Application
	{
        public static MainPage MainMasterPage;

        public static IContainer Container { get; set; }

        public App ()
		{
		    InitializeContainer();
		    InitializeComponent();
		    MainMasterPage = new MainPage();
		    MainPage = MainMasterPage;
        }

	    private void InitializeContainer()
	    {
	        ContainerBuilder builder = new ContainerBuilder();
	        builder.RegisterType<LocalDatabaseService>().As<ILocalDatabaseService>();
	        Container = builder.Build();
	    }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
