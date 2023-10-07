using System.Threading.Tasks;
using UI.Views;
using UI.Windows.Presenters;
using UI.Windows.Views;
using UnityEngine;
using Zenject;

namespace UI.Windows.Logic
{
    public class WindowsFactory
    {
        private readonly DiContainer _container;
        private readonly UiRoot _uiRoot;

        public WindowsFactory(DiContainer container, UiRoot uiRoot)
        {
            _container = container;
            _uiRoot = uiRoot;
        }
    
        public async Task<TPresenter> GetWindow<TPresenter, TView>() 
            where TPresenter : BaseWindowPresenter<TView> where TView : BaseView
        {
            var presenter = _container.Resolve<TPresenter>();
            var viewAsset = _container.Resolve<AsyncInject<TView>>();
        
            var prefab = await viewAsset;
        
            var view = Object.Instantiate(prefab, _uiRoot.transform);
            presenter.SetView(view);
        
            return presenter;
        }
    }
}