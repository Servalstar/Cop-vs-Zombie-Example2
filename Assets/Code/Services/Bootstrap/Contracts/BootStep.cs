using System.Threading.Tasks;
using UnityEngine;

namespace Services.Bootstrap.Contracts
{
    public abstract class BootStep : ScriptableObject
    {
        public abstract Task<bool> Execute();
    }
}