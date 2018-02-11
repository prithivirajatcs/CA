using System;
using System.Threading.Tasks;

namespace CANADA.Interface
{
    public interface IMessageHandler : IDisposable
    {
        void init<T>(T source);
        Task ShowMessage(string message);
        Task ShowMessage(string message, string title);
        Task<string> ShowMessageList(string title, string[] listString);
        Task<bool> ShowMessageConfirm(string message, string title, string buttonYesTitle, string buttonNoTitle);
        Task ShowProgressDialog(string message);
        Task HideProgressDialog();
    }
}
