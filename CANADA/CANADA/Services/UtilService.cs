using System;
using System.Collections.Generic;
using CANADA.Model;

namespace CANADA.Services
{
    public class UtilService
    {
        private static UtilService _instance;
        public static UtilService Instance => _instance ?? (_instance = new UtilService());

        public static String loggedInGlobalID;
        public static bool cookieFlag;

        public static string Login_URL;
        public static string HomePageURL;


        public List<CAList> RawPrincipleList
        {
            get;
            set;
        }

    }
}
