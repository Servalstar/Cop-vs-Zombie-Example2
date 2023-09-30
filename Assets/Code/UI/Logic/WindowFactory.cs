using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using UI.View;
using UnityEngine;
using Zenject;

public class WindowFactory
{
    private readonly DiContainer _container;
    private readonly IAssetProvider _assetProvider;
    
    public WindowFactory(DiContainer container, IAssetProvider assetProvider)
    {
        _container = container;
        _assetProvider = assetProvider;
    }
    
    public async Task<TPresenter> GetWindow<TPresenter, TView>() 
        where TPresenter : BaseWindowPresenter<TView> where TView : BaseWindow
    {
        var presenter = _container.Resolve<TPresenter>();
        var viewAsset = _container.Resolve<AsyncInject<TView>>();
        
        var prefab = await viewAsset;
        
        var view = Object.Instantiate(prefab);
        presenter.SetView(view);
        
        return presenter;
    }
}