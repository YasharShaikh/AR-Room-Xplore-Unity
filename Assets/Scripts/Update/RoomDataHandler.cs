using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoomDataHandler : MonoBehaviour
{
    [SerializeField] Button ViewContentButton;
    [SerializeField] RoomSo roomSo;
    [SerializeField] Image image;
    [SerializeField] TMP_Text Header;
    [SerializeField] TMP_Text SubHeader;


    private void Awake()
    {
        ViewContentButton.onClick.AddListener(ButtonPressed);
    }

    // Start is called before the first frame update
    void Start()
    {
        Header.text = roomSo.header;
        SubHeader.text = roomSo.subHeader;
        image.sprite = roomSo.displayImage;
    }

    public void ButtonPressed()
    {
        UIDataManager.Instance.ShowContentPanel();
        UIDataManager.Instance.RoomDataContainerFill(roomSo);
        ContentSetter.Instance.SetData();
    }
}
