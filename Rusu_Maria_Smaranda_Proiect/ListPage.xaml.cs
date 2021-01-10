using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rusu_Maria_Smaranda_Proiect.Models;

namespace Rusu_Maria_Smaranda_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var flist = (FilmList)BindingContext;
            flist.Date = DateTime.UtcNow;
            flist.Details = flist.Date.ToString() + "   Year:" + flist.Year.ToString();
            await App.Database.SaveFilmListAsync(flist);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var flist = (FilmList)BindingContext;
            await App.Database.DeleteFilmListAsync(flist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage((FilmList)
                this.BindingContext)
            { BindingContext = new Category() });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var filml = (FilmList)BindingContext;

            listView.ItemsSource = await App.Database.GetListCategoriesAsync(filml.ID);
        }
    }
}