using System;
using System.Threading.Tasks;
using CANADA.Model;

namespace CANADA.Interface
{
    public interface IDataSource
    {
        Task<AboutCanandaListModel> GetAboutList();
      
    }
}
