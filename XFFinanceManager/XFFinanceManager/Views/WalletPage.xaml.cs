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
	public partial class WalletPage
	{
		public WalletPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            WalletList.ItemsSource = App.Database.GetWalletManagerListForUI();
            
        }

        public async Task OnClicked_NewWalletAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new NewWalletManager()
                {
                    BindingContext = new WalletManager()
                }
            );
        }

        private void OnClicked_RemoveWalletAsync(object sender, EventArgs e)
        {            
        }
    }
}