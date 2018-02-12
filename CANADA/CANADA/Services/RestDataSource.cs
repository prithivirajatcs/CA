using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CANADA.Enum;
using CANADA.Interface;
using CANADA.Model;

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
                return retObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }



}

