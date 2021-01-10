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
    public partial class CategoryPage : ContentPage
    {
        FilmList fl;
        public CategoryPage(FilmList flist)
        {
            
            InitializeComponent();
            fl = flist;

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var category = (Category)BindingContext;
            await App.Database.SaveCategoryAsync(category);
            listView.ItemsSource = await App.Database.GetCategoriesAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            
            var category = (Category)BindingContext;
            await App.Database.DeleteCategoryAsync(category);
            listView.ItemsSource = await App.Database.GetCategoriesAsync();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCategoriesAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Category c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Category;
                var lc = new ListCategory()
                {
                    FilmListID = fl.ID,
                    CategoryID = c.ID
                };
                await App.Database.SaveListCategoryAsync(lc);
                c.ListCategories = new List<ListCategory> { lc };

                //await Navigation.PopAsync();
            }
        }
    }
}