using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PrivacyView : BaseViewWithData<PrivacyView.Data>
    {
        [SerializeField] private Button _acceptButton;

        protected override void Subscribe(Data data)
        {
            _acceptButton.onClick.AddListener(() => data.Callback?.Invoke());
        }

        protected override void Unsubscribe()
        {
            _acceptButton.onClick.RemoveAllListeners();
        }

        public readonly struct Data
        {
            public Data(Action callback)
            {
                Callback = callback;
            }

            public Action Callback { get; }
        }
    }
}