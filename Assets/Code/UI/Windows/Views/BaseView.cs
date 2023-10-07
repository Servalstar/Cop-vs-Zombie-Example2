using UnityEngine;

namespace UI.Windows.Views
{
    public abstract class BaseView : MonoBehaviour
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