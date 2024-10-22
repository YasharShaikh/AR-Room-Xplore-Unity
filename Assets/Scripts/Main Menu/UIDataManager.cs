using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDataManager : MonoBehaviour
{

    public static UIDataManager Instance;
    public RoomSo roomSoContainer;
   
    [Space]
    [SerializeField] Panel LandingPanel;
    [SerializeField] Panel MainMenuPanel;
    [SerializeField] Panel ContentPanel;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowLandingPage();
    }

    public void ShowLandingPage()
    {
        LandingPanel.Show();
        MainMenuPanel.Hide();
        ContentPanel.Hide();
    }
    public void ShowMainMenuPanel()
    {
        LandingPanel.Hide();
        MainMenuPanel.Show();
        ContentPanel.Hide();
    }
    public void ShowContentPanel()
    {
        LandingPanel.Hide();
        MainMenuPanel.Hide();
        ContentPanel.Show();
    }

    public void RoomDataContainerFill(RoomSo roomSo)
    {
        roomSoContainer.header = roomSo.header;
        roomSoContainer.subHeader = roomSo.subHeader;
        roomSoContainer.size = roomSo.size;
        roomSoContainer.price = roomSo.price;
        roomSoContainer.displayImage = roomSo.displayImage;
        roomSoContainer.roomPrefab = roomSo.roomPrefab;
        roomSoContainer.livingRoomPrefab = roomSo.livingRoomPrefab;
        roomSoContainer.kitchenPrefab = roomSo.kitchenPrefab;
        roomSoContainer.bedroom1Prefab = roomSo.bedroom1Prefab;
        roomSoContainer.bedroom2Prefab = roomSo.bedroom2Prefab;
        roomSoContainer.bedroom3Prefab = roomSo.bedroom3Prefab;
    }
    public void RoomDataContainerNull()
    {
        roomSoContainer.header = null;
        roomSoContainer.subHeader =null;
        roomSoContainer.size = null;
        roomSoContainer.price = null;
        roomSoContainer.displayImage = null;
        roomSoContainer.roomPrefab = null;
        roomSoContainer.livingRoomPrefab = null;
        roomSoContainer.kitchenPrefab = null;
        roomSoContainer.bedroom1Prefab = null;
        roomSoContainer.bedroom2Prefab = null;
        roomSoContainer.bedroom3Prefab = null;
    }

    

    public void BackButtonPressed()
    {
        roomSoContainer = null;
    }
}
