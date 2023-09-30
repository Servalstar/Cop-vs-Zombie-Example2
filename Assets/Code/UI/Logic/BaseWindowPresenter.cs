using UI.View;

public abstract class BaseWindowPresenter<T> where T : BaseWindow
{
    private T _view;

    public virtual void SetView(T view)
    {
        _view = view;
    }
    
    public virtual void Open()
    {
        _view.Open();
    }
    
    protected void Close()
    {
        _view.Close();
    }
}