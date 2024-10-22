using UnityEngine;

public class MainMenuPanel : Panel
{

    public override void Show()
    {
        Debug.Log("Show from MainMenuPanel");
        base.Show();
    }
    public override void Hide()
    {
        Debug.Log("Hide from MainMenuPanel");
        base.Hide();
    }
}
