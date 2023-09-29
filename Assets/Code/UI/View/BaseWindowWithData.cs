namespace UI.View
{
    public abstract class BaseWindowWithData<T> : BaseWindow where T : struct
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