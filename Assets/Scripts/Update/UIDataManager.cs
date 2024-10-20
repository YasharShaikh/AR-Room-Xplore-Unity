using UnityEngine;

public class UIDataManager : MonoBehaviour
{

    public static UIDataManager Instance;
    public RoomSo roomSoContainer;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void BackButtonPressed()
    {
        roomSoContainer = null;
    }
}
