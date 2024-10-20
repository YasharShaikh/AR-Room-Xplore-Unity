using UnityEngine;

[CreateAssetMenu(fileName = "Room Data", menuName = "Room Data")]
public class RoomSo : ScriptableObject
{
    [Header("UI Info")]
    public string header;           // Room header text
    public string subHeader;        // Room sub-header text
    public string size;       // Square footage of the room
    public string price;            // Price of the room
    public Sprite displayImage;     // Display image for UI

    [Header("Visuals")]
    public GameObject roomPrefab;          // Main room prefab
    public GameObject livingRoomPrefab;    // Living room prefab
    public GameObject kitchenPrefab;       // Kitchen prefab
    public GameObject bedroom1Prefab;      // Bedroom 1 prefab
    public GameObject bedroom2Prefab;      // Bedroom 2 prefab
    public GameObject bedroom3Prefab;      // Bedroom 3 prefab
}
