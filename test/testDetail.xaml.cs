using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace test
{
	public partial class testDetail : ContentPage
	{
		public testDetail(Osoba item)
		{
			InitializeComponent();
			fill(item);
		}

		void fill(Osoba item)
		{
			jmeno.Text = item.Jmeno;
			prijmeni.Text = item.Prijmeni;
			vek.Text = Convert.ToString(item.Vek);
			bydliste.Text = item.Bydliste;
		}

	}
}
