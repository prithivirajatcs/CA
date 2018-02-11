using System;
using System.Collections.Generic;
using CANADA.Interface;

namespace CANADA.Services
{
    public class RestDataSource : IDataSource
    {
        #region "End-Points"
        static Object rootobject;
        static Object response;
        private string baseURL = "https://demo2974790.mockable.io/viewprofile";
        //private string baseURL = "http://redcscgtmes03.ced.corp.cummins.com:8080/ShippingPOC/"; //TODO: Prod service URL
        public static string Login_URL = "";
        public static string HomePage_URL = "";

        #endregion

        #region "Constructors"

        public RestDataSource()
        {
        }

        public RestDataSource(string flag)
        {
            switch (flag)
            {
                case "QA":
                   // HomePage_URL = Constants.HomePage_URL_QA;
                    break;
                case "PROD":
                   // HomePage_URL = Constants.HomePage_URL_PROD;
                    break;
            }
        }
        #endregion

        //public async Task<BestPracticesListModel> GetBestPracticesList()
        //{
        //    try
        //    {
        //        BestPracticesListModel retObj = new BestPracticesListModel();
        //        DataService service = new DataService(Constants.Environment);
        //        //string baseAddress = "https://demo2974790.mockable.io/";
        //        //await service.GetResult("", baseAddress, "", "");


        //        IServiceHandler serviceHandler = RestService.GetInstance();
        //        serviceHandler.Init(HomePage_URL, Miscellaneous.SericeType.STUB);

        //        Dictionary<string, string> reqParams = new Dictionary<string, string>();

        //        reqParams.Add("globalId", UtilService.globalId);
        //        reqParams.Add("SM_USER", UtilService.globalId);
        //        reqParams.Add("channel", "mobile");

        //        retObj = await serviceHandler.PostRequest<BestPracticesListModel>("", "", reqParams, null);

        //        return retObj;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

    }
}
