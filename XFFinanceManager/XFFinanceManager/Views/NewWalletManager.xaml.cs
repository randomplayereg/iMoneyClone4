using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Models;
using XFFinanceManager.Resources;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWalletManager : ContentPage
    {

        List<string> categoryList = new List<string>() {
            "ATM", "Cash", "Bitcoin", "Insurance"
        };

        public NewWalletManager()
        {
            InitializeComponent();
            walletCategory.ItemsSource = categoryList;
        }

        private async void walletManager_Saved(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryName.Text))
            {
                if (!string.IsNullOrEmpty(initialAmount.Text))
                {
                    var walletManagerItem = (WalletManager)BindingContext;

                    App.Database.SaveWalletManagerAsync(walletManagerItem);

                    int monei; int.TryParse(initialAmount.Text, out monei);
                    // if initial amount > 0, create a FinanceManager that have the same amount of money as the money value of initial input
                    if (monei > 0)
                    { 
                        //initial.Date = DateTime.Now;
                        //initial.Category = 0;
                        //initial.Money = monei;
                        //initial.Name = "Initial Amount";
                        //initial.Type = 1;
                        //initial.WalletId = walletManagerItem.Id;
                        FinanceManager initial = new FinanceManager("Initial Amount", 0, 1, monei, "", DateTime.Now, walletManagerItem.Id);
                        App.Database.SaveFinanceManagerAsync(initial);
                    }

                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("", AppResources.MessageMoney, AppResources.Close);
                }
            }
            else
            {
                await DisplayAlert("", AppResources.MessageName, AppResources.Close);
            }
        }
    }
}