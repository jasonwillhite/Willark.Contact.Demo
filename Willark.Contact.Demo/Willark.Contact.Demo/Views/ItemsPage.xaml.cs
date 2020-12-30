using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Willark.Contact.Demo.Models;
using Willark.Contact.Demo.Views;
using Willark.Contact.Demo.ViewModels;

namespace Willark.Contact.Demo.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        async void SwipeItem_Invoked(System.Object sender, System.EventArgs e)
        {
            var item = (sender as SwipeItem)?.BindingContext as Item;            
            if (await DisplayAlert("Delete", "Are you sure you want to delete this?", "Yes", "No"))
            {
                MessagingCenter.Send(this, "DeleteItem", item);
            }            
        }
    }
}