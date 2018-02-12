using System;
using System.Threading.Tasks;
using CANADA.Model;

namespace CANADA.Interface
{
    public interface IDataSource
    {
        Task<AboutCanandaListModel> GetAboutList();
        //Task<List<BestPractice>> RemoveBestPractice(string practiceId);
        //Task<string> GetSMcookie(UserInfoModel loginModel);
    }
}
