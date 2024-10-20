using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomDataAccess : MonoBehaviour
{
    public static RoomDataAccess instance;

    public int RoomId;

    [Header("References")]
    [SerializeField] CanvasGroup Content;
    [SerializeField] Transform ContentTransform;
    [SerializeField] Image ContentImage;
    [Space]
    [SerializeField] CanvasGroup BottomNav;
    [SerializeField] Transform BottomNavTransform;
    [SerializeField] Image BottomNavImage;
    [Space]
    [SerializeField] TMP_Text RoomNameText;
    [SerializeField] TMP_Text CarpetAreaText;
    [SerializeField] TMP_Text RoomTypeText;
    [SerializeField] TMP_Text AddressText;

    [Header("For UI")]
    [SerializeField] string RoomName;
    [SerializeField] string CarpetArea;
    [SerializeField] string RoomType;
    [SerializeField] string Address;

    [Header("Speeds and Positions")]
    [SerializeField] Vector3 OnViewPosition;
    [SerializeField] Vector3 ResetPosition;
    [SerializeField] Vector3 OutViewDownPosition;
    [SerializeField] float AnimationSpeed;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void OnButtonClicked()
    {
        Debug.Log("BUtton clicked");
        if (RoomNameText != null) RoomNameText.text = RoomName;
        if (CarpetAreaText != null) CarpetAreaText.text = CarpetArea;
        if (RoomTypeText != null) RoomTypeText.text = RoomType;
        if (AddressText != null) AddressText.text = Address;

        // Animations
        StartCoroutine(TabCall());
    }

    private IEnumerator TabCall()
    {
        ContentTransform.DOLocalMove(OnViewPosition, AnimationSpeed);
        BottomNavTransform.DOLocalMove(OutViewDownPosition, AnimationSpeed);
        yield return new WaitForSeconds(AnimationSpeed);
        RoomNameText.DOFade(1, AnimationSpeed);
        CarpetAreaText.DOFade(1, AnimationSpeed);
    }
}
