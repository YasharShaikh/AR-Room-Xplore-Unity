using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentSetter : MonoBehaviour
{
    public static ContentSetter Instance;

    [SerializeField] UIDataManager manager;
    [Space]
    [SerializeField] TMP_Text headerText;
    [SerializeField] TMP_Text subHeaderText;
    [SerializeField] Image mockImage;
    [SerializeField] TMP_Text priceText;
    [SerializeField] TMP_Text sizeText;
    private void Awake()
    {
        Instance = this;
    }
    public void SetData()
    {
        headerText.text = manager.roomSoContainer.header;
        subHeaderText.text = manager.roomSoContainer.subHeader;
        mockImage.sprite = manager.roomSoContainer.displayImage;
        priceText.text = manager.roomSoContainer.price;
        sizeText.text = manager.roomSoContainer.size;
    }
}
