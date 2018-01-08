﻿using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XFFinanceManager.Data;
using XFFinanceManager.Interface;
using XFFinanceManager.Resources;

namespace XFFinanceManager
{
    public partial class App : Application
    {
        //public NavigationPage AppNavPage = new NavigationPage(new MainPage());

        static FinanceManagerDatabase database;

        public App()
        {
            CurrentWalletId = -1;

            InitializeComponent();

            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            MainPage = new Views.LoginPage();            
        }

        public static FinanceManagerDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new FinanceManagerDatabase(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("FinanceManager.db3"));
                }
                return database;
            }
        }

        public int ResumeAtFinanceManagerId { get; set; }
        public int CurrentWalletId { get; set; } // current id of the wallet
        // income/expense page only show list of financemanagers which belong to this specific wallet

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
