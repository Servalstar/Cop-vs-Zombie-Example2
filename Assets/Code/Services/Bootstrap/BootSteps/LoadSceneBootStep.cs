using System;
using System.Threading.Tasks;
using Services.Bootstrap.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/LoadSceneBootStep", fileName = "LoadSceneBootStep")]
    public class LoadSceneBootStep : BootStep
    {
        [SerializeField] private string _sceneName;

        public override async Task<bool> Execute()
        {
            if (string.IsNullOrEmpty(_sceneName))
            {
                throw new ArgumentNullException(nameof(_sceneName));
            }
            
            var asyncOperation = SceneManager.LoadSceneAsync(_sceneName);
            
            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
            
            return true;
        }
    }
}