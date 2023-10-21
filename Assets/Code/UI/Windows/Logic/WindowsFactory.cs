using System.Threading.Tasks;
using UI.Common;
using UI.Windows.Contracts;
using UI.Windows.Views;
using UnityEngine;
using Zenject;

namespace UI.Windows.Logic
{
    public class WindowsFactory
    {
        private readonly DiContainer _container;
        private readonly UiRoot _uiRoot;

        protected WindowsFactory(DiContainer container, UiRoot uiRoot)
        {
            _container = container;
            _uiRoot = uiRoot;
        }
    
        public async Task OpenWindow<TView>() where TView : BaseView
        {
            var presenter = await CreateWindow<TView>();
            presenter.Open();
        }
        
        public async Task OpenWindow<TView>(TaskCompletionSource<bool> awaiter) where TView : BaseView
        {
            var presenter = await CreateWindow<TView>();
            presenter.Open(awaiter);
        }

        private async Task<IWindowPresenter<TView>> CreateWindow<TView>() where TView : BaseView
        {
            var presenter = _container.Resolve<IWindowPresenter<TView>>();
            var viewAsset = _container.Resolve<AsyncInject<TView>>();
        
            var prefab = await viewAsset;
        
            var view = Object.Instantiate(prefab, _uiRoot.transform);
            presenter.SetView(view);

            return presenter;
        }
    }
}