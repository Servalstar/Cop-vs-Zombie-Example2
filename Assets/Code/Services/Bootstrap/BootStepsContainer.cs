using Services.Bootstrap.Contracts;
using UnityEngine;

namespace Services.Bootstrap
{
    [CreateAssetMenu(menuName = "Bootstrap/BootStepsContainer", fileName = "BootStepsContainer")]
    public class BootStepsContainer : ScriptableObject
    {
        [SerializeField] private BootStep[] _bootSteps;
        
        public BootStep[] BootSteps => _bootSteps;
    }
}