using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CANADA.Enum;
using CANADA.Interface;
using CANADA.Model;
using Newtonsoft.Json;

namespace CANADA.Services
{
    public class RestService : IServiceHandler
    {
        public RestService()
        {
        }

        public static RestService objShared;
        public static RestService GetInstance()
        {
            if (objShared == null)
            {
                objShared = new RestService();
            }
            return objShared;
        }
        public void Init(string baseUrl, Miscellaneous.SericeType serType)
        {
            this.baseURL = baseUrl;
            this.serviceType = serType;
        }
        private string baseURL;
        public string BaseURL
        {
            get
            {
                return this.baseURL;
            }

            set
            {
                this.baseURL = value;
            }
        }
        Miscellaneous.SericeType serviceType;
        public Miscellaneous.SericeType ServiceType
        {
            get
            {
                return serviceType;
            }

            set
            {
                serviceType = value;
            }
        }

        public async Task<T> GetRequest<T>(string urlSuffix, string requestStr, Type reqType) where T : new()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(BaseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    if (urlSuffix != null && urlSuffix.Trim().Length > 0)
                    {
                        if (requestStr != null && requestStr.Trim().Length > 0)
                        {
                            requestStr = urlSuffix + "/" + requestStr;
                        }
                        requestStr = urlSuffix;
                    }

                    var retTask = client.GetAsync(requestStr);
                   // Task.WaitAll(retTask);
                    await  Task.WhenAll(retTask);
                    HttpResponseMessage response = retTask.Result;// await client.GetAsync(requestStr);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var strResponse = await response.Content.ReadAsStringAsync();

                        var responseObj = (T)JsonConvert.DeserializeObject(strResponse, typeof(T));
                       
                        return responseObj;
                    }
                    else
                    {
                       // var responseError = "{\"status_code:'FAILED'\"}";
                        var responseError = string.Format("Bad Request: {0}\n{1}\n{2}",
                                              response.StatusCode,
                                              response.ReasonPhrase,
                                                        response.Headers);
                        var responseObj = (T)JsonConvert.DeserializeObject(responseError, typeof(T));

                        return responseObj;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return (T)(object)"{}";
        }

      

    }
}
