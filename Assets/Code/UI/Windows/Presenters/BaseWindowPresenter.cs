using System.Threading.Tasks;
using UI.Windows.Contracts;
using UI.Windows.Views;

namespace UI.Windows.Presenters
{
    public abstract class BaseWindowPresenter<T> : IWindowPresenter<T> where T : BaseView
    {
        protected T _view;
        protected TaskCompletionSource<bool> _awaiter;

        public void SetView(T view)
        {
            _view = view;
        }
    
        public virtual void Open()
        {
            _view.Open();
        }
    
        public virtual void Open(TaskCompletionSource<bool> awaiter)
        {
            _awaiter = awaiter;
            Open();
        }
    
        protected void Close()
        {
            _view.Close();
        }
    }
}