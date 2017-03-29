using System;
using System.IO;
using test.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace test.Droid
{
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}