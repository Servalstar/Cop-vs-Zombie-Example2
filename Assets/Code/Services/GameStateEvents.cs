using System;
using UnityEngine;

namespace Services
{
    public class GameStateEvents : MonoBehaviour
    {
        public event Action Finish;
        public event Action Quite;
        
        public void OnFinish()
        {
            Finish?.Invoke();
        }
        
        public void OnApplicationQuit()
        {
            Quite?.Invoke();
        }
    }
}