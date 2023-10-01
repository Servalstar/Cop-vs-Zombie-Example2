using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.AssetManagement.Contracts
{
    public interface IAssetProvider
    {
        Task Initialize();
        Task<T> Load<T>(string address) where T : class;
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        Task<GameObject> Instantiate(string address);
        Task<GameObject> Instantiate(string address, GameObject parent);
        void Cleanup();
    }
}