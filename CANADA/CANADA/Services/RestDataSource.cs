using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CANADA.Enum;
using CANADA.Interface;
using CANADA.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using CANADA.Constants;


namespace CANADA.Services
{
    public class RestDataSource : IDataSource
    {
        #region "Constructors"
        public RestDataSource()
        {
        }

        #endregion

        public async Task<AboutCanandaListModel> GetAboutList()
        {
            try
            {
                AboutCanandaListModel retObj = new AboutCanandaListModel();
               
                IServiceHandler serviceHandler = RestService.GetInstance();
                serviceHandler.Init("https://dl.dropboxusercontent.com/s/2iodh4vg0eortkl/facts.json", Miscellaneous.SericeType.STUB);
                retObj = await serviceHandler.GetRequest<AboutCanandaListModel>("", "", null);
                string resp = JsonConvert.SerializeObject(retObj);
                IFileStorage filestorage = DependencyService.Get<IFileStorage>();
                string path=filestorage.getpath(resp);

                IFileStorage readfile = DependencyService.Get<IFileStorage>();
                string data = readfile.readdata(path);
                AboutCanandaListModel retdata= JsonConvert.DeserializeObject<AboutCanandaListModel>(data);

                return retdata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
    }



}

