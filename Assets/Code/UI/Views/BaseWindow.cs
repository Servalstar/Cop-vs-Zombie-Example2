using UnityEngine;

namespace UI.Views
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}