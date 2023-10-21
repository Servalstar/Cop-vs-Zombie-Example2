using System.Threading.Tasks;
using UI.Windows.Views;

namespace UI.Windows.Contracts
{
    public interface IWindowPresenter<in T> where T : BaseView
    {
        void SetView(T view);
        void Open();
        void Open(TaskCompletionSource<bool> awaiter);
    }
}