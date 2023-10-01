using System.Threading.Tasks;
using UI.View;

public class PrivacyWindowPresenter : BaseWindowPresenter<PrivacyWindow>
{
    private PrivacyWindow _view;

    public override void SetView(PrivacyWindow view)
    {
        _view = view;
        base.SetView(view);
    }

    public override void Open(TaskCompletionSource<bool> awaiter)
    {
        _awaiter = awaiter;
        _view.Open(new PrivacyWindow.Data(AcceptPrivacy));
    }

    private void AcceptPrivacy()
    {
        _awaiter.SetResult(true);
        Close();
    }
}