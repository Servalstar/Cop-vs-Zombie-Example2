using UI.Windows.Views;

namespace UI.Views
{
    public abstract class BaseViewWithData<T> : BaseView where T : struct
    {
        public void Open(T data)
        {
            Subscribe(data);
            base.Open();
        }
        
        public override void Close()
        {
            Unsubscribe();
            base.Close();
        }

        protected abstract void Subscribe(T data);
        protected abstract void Unsubscribe();
    }
}