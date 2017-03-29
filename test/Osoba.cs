using System;
using SQLite;

namespace test
{
	/// <summary>
	/// Třída osoba (ted je možné použít v projktu další datoví tip a to Osoba)
	/// </summary>
	public class Osoba
	{
		//Jelikož se ukládá do DB musí mít nastaven primarní klíč a ID
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		//jednostlive atributy
		public string Jmeno { get; set; }
		public string Prijmeni { get; set; }
		public int Vek { get; set; }
		public string Bydliste { get; set; }

		//Data je nutné převest nasring pro zprávné čtení
		public override string ToString()
		{
			return Jmeno + " " + Prijmeni + " " + Bydliste + " " + Vek;
		}
	}
}
