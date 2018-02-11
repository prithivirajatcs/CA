using System;
using System.Threading.Tasks;
using CANADA.Enum;
namespace CANADA.Interface
{
    public interface IServiceHandler
    {
        string BaseURL { get; set; }
        Miscellaneous.SericeType ServiceType { get; set; }

        void Init(string baseUrl, Miscellaneous.SericeType serType);
        Task<T> GetRequest<T>(string urlSuffix, string requestStr, Type reqType) where T : new();
    }
}
