using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Models;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsPage : ContentPage
    {
        public AccountsPage()
        {     
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //get wallet list for showing
            List<WalletManager> walletList = App.Database.GetWalletManagerListForUI();
            walletListView.ItemsSource = walletList;

            //calculate total balance of all wallets to show
            int balance = 0;
            foreach (var wallet in walletList)
            {
                balance += wallet.Amount;
            }
            totalBalanceText.Text = "Total balance: " + balance.ToString();
        }

        private async void addNewAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewWalletManager()
            {
                BindingContext = new WalletManager()
            });
        }

        private async void walletListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailWalletManager()
                {
                    BindingContext = e.SelectedItem as WalletManager
                });
            }
        }
    }
}