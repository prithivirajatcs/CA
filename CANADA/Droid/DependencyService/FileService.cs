using System;
using System.IO;
using CANADA.Droid.DependencyService;
using CANADA.Interface;
using CANADA.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace CANADA.Droid.DependencyService
{
    public class FileService:IFileStorage
    {
        public FileService()
        {
        }

        public string getpath(string json)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filename = Path.Combine(documents, "data.txt");
            System.Diagnostics.Debug.WriteLine(filename);
            File.WriteAllText(filename, json);
            return filename;
        }


        public string readdata(string filename){
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }

       

       

    }
}
