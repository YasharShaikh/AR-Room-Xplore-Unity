using UnityEngine;
using UnityEngine.UI;

public class RoomHandler : MonoBehaviour
{

    [SerializeField] Button _ShowLivingRoom;
    [SerializeField] Button _ShowKitchenRoom;
    [SerializeField] Button _ShowBedroom1Room;
    [SerializeField] Button _ShowBedroom2Room;
    [SerializeField] Button _ShowBedroom3Room;
    [SerializeField] Button _showAllRoom;
    [Space]
    [SerializeField] Button _BurgerButton;
    [SerializeField] Sprite OpenSprite;
    [SerializeField] Sprite CloseSprite;
    bool burgerMenuOpen = false;


    private void Awake()
    {
        _ShowLivingRoom.onClick.AddListener(ShowLiving);
        _ShowKitchenRoom.onClick.AddListener(ShowKitchen);
        _ShowBedroom1Room.onClick.AddListener(ShowBedroom1);
        _ShowBedroom2Room.onClick.AddListener(ShowBedroom2);
        _ShowBedroom3Room.onClick.AddListener(ShowBedroom3);
        _showAllRoom.onClick.AddListener(ShowAllRoom);
    }

    public void ShowLiving()
    {

    }
    public void ShowKitchen()
    {

    }
    public void ShowBedroom1()
    {
        if (ARGroundscapePlacer.Instance.roomSo.bedroom1Prefab != null)
        {
            //show UI button to view bedroom1
            //hide other rooms with animation

        }
    }

    public void ShowBedroom2()
    {
        if (ARGroundscapePlacer.Instance.roomSo.bedroom2Prefab != null)
        {
            //show UI button to view bedroom1
            //hide other rooms with animation

        }
    }
    public void ShowBedroom3()
    {
        if (ARGroundscapePlacer.Instance.roomSo.bedroom3Prefab != null)
        {
            //show UI button to view bedroom1
            //hide other rooms with animation

        }
    }
    public void ShowAllRoom()
    {

    }

    public void OpenBurgerMenu()
    {
        if(burgerMenuOpen)
        {

        }
    }
}
