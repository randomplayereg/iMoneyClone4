using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Views;
using XFFinanceManager.Resources;
using XFFinanceManager.Models;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailWalletManager : ContentPage
    {
        List<string> categoryList = new List<string>() {
            "ATM", "Cash", "Bitcoin", "Insurance"
        };

        public DetailWalletManager()
        {            
            InitializeComponent();
            walletCategory.ItemsSource = categoryList;
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var walletManagerItem = (WalletManager)BindingContext;

            App.Database.SaveWalletManagerAsync(walletManagerItem);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var userClick = await DisplayAlert("", AppResources.MessageDelete, AppResources.Yes, AppResources.No);
            if (userClick)
            {
                var walletManagerItem = (WalletManager)BindingContext;

                // if the current wallet id of the App is the same as the wallet being deleted, we need to change it to avoid error
                if (((App)App.Current).CurrentWalletId == walletManagerItem.Id) {
                    ((App)App.Current).CurrentWalletId = -1;
                }

                App.Database.DeleteWalletManagerAsync(walletManagerItem);

                await Navigation.PopAsync();
            }
        }
    }
}