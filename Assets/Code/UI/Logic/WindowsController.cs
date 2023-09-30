using System.Threading.Tasks;
using UI.View;

public class WindowsController
{
    private readonly WindowsFactory _windowsFactory;

    public WindowsController(WindowsFactory windowsFactory)
    {
        _windowsFactory = windowsFactory;
    }
    
    public async Task Open<TPresenter, TView>() 
        where TPresenter : BaseWindowPresenter<TView> where TView : BaseWindow
    {
        var window = await _windowsFactory.GetWindow<TPresenter, TView>();
        
        // Set Root UI
        window.Open();
    }
}