using UnityEngine;
using UnityEngine.UI;

public class LandingPanel : Panel
{
    [Header("Functionality")]
    [SerializeField] Button getStartedButton;

    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    private void Awake()
    {
        getStartedButton.onClick.AddListener(OnClickGetStartedButton);
    }

    public void OnClickGetStartedButton()
    {
        UIDataManager.Instance.ShowMainMenuPanel();
    }
}
