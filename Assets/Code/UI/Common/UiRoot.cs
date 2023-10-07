using UnityEngine;

namespace UI.Common
{
    public class UiRoot : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        private void OnEnable()
        {
            _canvas.worldCamera = Camera.main;
        }
    }
}