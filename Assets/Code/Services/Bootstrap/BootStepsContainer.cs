using Services.Bootstrap.Contracts;
using UnityEngine;

namespace Services.Bootstrap
{
    [CreateAssetMenu(menuName = "Bootstrap/BootStepsContainer", fileName = "BootStepsContainer")]
    public class BootStepsContainer : ScriptableObject
    {
        [SerializeField] private BootStep[] _initBootSteps;
        [SerializeField] private BootStep[] _sceneBootSteps;
        
        public BootStep[] InitBootSteps => _initBootSteps;
        public BootStep[] SceneBootSteps => _sceneBootSteps;
    }
}