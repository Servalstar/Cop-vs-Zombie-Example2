using System.Threading.Tasks;
using UI.Views;

namespace UI.Windows.Presenters
{
    public class PrivacyWindowPresenter : BaseWindowPresenter<PrivacyView>
    {
        public override void Open(TaskCompletionSource<bool> awaiter)
        {
            _awaiter = awaiter;
            _view.Open(new PrivacyView.Data(AcceptPrivacy));
        }

        private void AcceptPrivacy()
        {
            _awaiter.SetResult(true);
            Close();
        }
    }
}