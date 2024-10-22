
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContentPanel : Panel
{

    [Header("Scene Name")]
    [SerializeField] string groundQuestScene;
    [SerializeField] string roomQuestScene;
    [Space]
    [SerializeField] Button ReturnButton;
    [SerializeField] Button GroundScape;
    [SerializeField] Button RoomScape;
    private void Awake()
    {
        ReturnButton.onClick.AddListener(OnClickReturnButton);
        GroundScape.onClick.AddListener(OnClickGroundQuest);
        RoomScape.onClick.AddListener(OnClickRoomQuest);
    }

    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }

    public void OnClickGroundQuest()
    {
        SceneManager.LoadScene(groundQuestScene);
    }

    public void OnClickRoomQuest()
    {
        SceneManager.LoadScene(roomQuestScene);
    }

    void OnClickReturnButton()
    {
        UIDataManager.Instance.ShowMainMenuPanel();
        UIDataManager.Instance.RoomDataContainerNull();
    }
}
