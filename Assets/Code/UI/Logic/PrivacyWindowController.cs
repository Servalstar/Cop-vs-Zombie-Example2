using UI.View;
using UnityEngine;

public class PrivacyWindowController : BaseWindowController<PrivacyWindow>
{
    private readonly PrivacyWindow _view;
    
    public PrivacyWindowController(PrivacyWindow view) : base(view)
    {
        _view = view;
    }

    public override void Open()
    {
        _view.Open(new PrivacyWindow.Data(AcceptPrivacy));
    }
    
    private void AcceptPrivacy()
    {
        Debug.Log("Accepted");
        Close();
    }
}