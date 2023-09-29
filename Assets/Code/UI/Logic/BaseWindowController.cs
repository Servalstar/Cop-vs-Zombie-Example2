using UI.View;

public class BaseWindowController<T> where T : BaseWindow
{
    private readonly T _view;
    
    protected BaseWindowController(T view)
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