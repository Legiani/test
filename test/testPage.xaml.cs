using System;
using Xamarin.Forms;

namespace test
{
	public partial class testPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:test.testPage"/> class.
		/// </summary>
		public testPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Reakce na vstupní tlačítko "button"
		/// </summary>
		/// <returns>The button.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void button(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new testListView());
		}
	}
}
