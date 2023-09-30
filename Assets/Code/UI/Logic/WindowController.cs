using System.Threading.Tasks;
using UI.View;

public class WindowController
{
    private readonly WindowFactory _windowFactory;

    public WindowController(WindowFactory windowFactory)
    {
        _windowFactory = windowFactory;
    }

    public async Task Open<TPresenter, TView>() 
        where TPresenter : BaseWindowPresenter<TView> where TView : BaseWindow
    {
        var window = await _windowFactory.GetWindow<TPresenter, TView>();
        
        // Set Root UI
        window.Open();
    }
}