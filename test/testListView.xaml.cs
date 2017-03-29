using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace test
{
	public partial class testListView : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:test.testListView"/> class.
		/// </summary>
		public testListView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Stane se při zmačknutí horního tlačítka
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void upButton(object sender, EventArgs args)
		{
			//Navigation.PushModalAsync(new testDetail());
		}

		/// <summary>
		/// Otevře stránku na vložení nové položky
		/// </summary>
		/// <returns>The pridat.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void pridat(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new testNew());
		}

		/// <summary>
		/// Stane se při navratu na danou stranku
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			fill();
		}

		public async void SelectedItemMethod(object sender, ItemTappedEventArgs e)
		{
			////vytvoření Item s přijatímy daty
			Osoba item = e.Item as Osoba;
			//vytvoření spojení s db
			var dbConnection = App.Database;
			//db uživatelu
			Database userDatabase = App.Database;
			//zapis(update) dat do db
			await App.Database.SaveItemAsync(item);
			//počkej pro stabilitu
			await Task.Delay(1);
			fill();
		}

		/// <summary>
		/// Vloží data do ListVIEW
		/// </summary>
		public void fill()
		{
			var dbConnection = App.Database;
			Database database = App.Database;
			ListViewFormatted.ItemsSource = App.Database.GetItemsAsync().Result;

		}

		/// <summary>
		/// Možnost editace jednotlivích položek
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void OnEdit(object sender, EventArgs e)
		{
			//var mi = ((MenuItem)sender);
			DisplayAlert("Ops :-)", "Tato možnost zatím není možná, smažte položku a vytvořte si jí znovu.", "OK");

		}

		/// <summary>
		/// Možnost smazání položky
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);

			int derp = (int)mi.CommandParameter;
			//vytvoření spojení s db
			var dbConnection = App.Database;
			//db věcí
			Database items = App.Database;
			//přikaz smaž
			App.Database.DeleteItemAsync(App.Database.GetItemAsync(derp).Result);
			//čekej pro stabilitu
			Task.Delay(1);
			//vrat se na domovskou obrazovku
			//Navigation.PopToRootAsync();
			fill();
			//hlaška
			DisplayAlert("Smazano", "Prvek s ID: " + derp + " byl smazán.", "OK");
		}
	}
}
