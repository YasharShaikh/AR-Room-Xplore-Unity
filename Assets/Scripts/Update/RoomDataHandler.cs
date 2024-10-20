using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomDataHandler : MonoBehaviour
{

    [SerializeField] RoomSo roomSo;
    [SerializeField] Image image;
    [SerializeField] TMP_Text Header;
    [SerializeField] TMP_Text SubHeader;


    // Start is called before the first frame update
    void Start()
    {
        image.sprite = roomSo.displayImage;
        Header.text = roomSo.header;
        SubHeader.text = roomSo.subHeader;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPressed()
    {
        UIDataManager.Instance.roomSoContainer = roomSo;
    }
}
