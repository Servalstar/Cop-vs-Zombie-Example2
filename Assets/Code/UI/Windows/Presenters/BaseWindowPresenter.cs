using System.Threading.Tasks;
using UI.Views;

namespace UI.Presenters
{
    public abstract class BaseWindowPresenter<T> where T : BaseWindow
    {
        private T _view;

        protected TaskCompletionSource<bool> _awaiter;

        public virtual void SetView(T view)
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