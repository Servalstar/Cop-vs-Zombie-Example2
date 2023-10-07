using System.Threading.Tasks;
using UI.Windows.Presenters;
using UI.Windows.Views;

namespace UI.Windows.Logic
{
    public class WindowsController
    {
        private readonly WindowsFactory _windowsFactory;

        public WindowsController(WindowsFactory windowsFactory)
        {
            _windowsFactory = windowsFactory;
        }
    
        public async Task Open<TPresenter, TView>() 
            where TPresenter : BaseWindowPresenter<TView> where TView : BaseView
        {
            var window = await _windowsFactory.GetWindow<TPresenter, TView>();
            window.Open();
        }
    
        public async Task Open<TPresenter, TView>(TaskCompletionSource<bool> awaiter) 
            where TPresenter : BaseWindowPresenter<TView> where TView : BaseView
        {
            var window = await _windowsFactory.GetWindow<TPresenter, TView>();
            window.Open(awaiter);
        }
    }
}