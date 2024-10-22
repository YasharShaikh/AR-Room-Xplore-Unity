using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public int roomID;

    [Header("References")]
    [SerializeField] CanvasGroup content;
    [SerializeField] Transform contentTransform;
    [SerializeField] Image contentImage;
    [Space]
    [SerializeField] CanvasGroup bottomNav;
    [SerializeField] Transform bottomNavTransform;
    [SerializeField] Image bottomNavImage;

    [Header("Speeds and Positions")]
    [SerializeField] Vector3 onViewPosition;
    [SerializeField] Vector3 resetPosition;
    [SerializeField] Vector3 downUpPosition;
    [SerializeField] float animationSpeed;

    [Header("Add to Favorite")]
    [SerializeField] Transform favouriteButtonTransform;
    bool isFavouriteButtonPressed;


    [Header("Scene Name")]
    [SerializeField] string groundQuestScene;
    [SerializeField] string roomQuestScene;



    private void Awake()
    {
        //instance = this;
    }

    private void Update()
    {
        Debug.Log("WOrking from uimanager");
    }
    public void OnBackButtonPressed()
    {
        StartCoroutine(ResetTab());
    }

    public void GroundScapeClicked()
    {
        string temp = groundQuestScene;
        PlayerPrefs.SetInt("GroundQuest",roomID);
        SceneManager.LoadScene(temp);
        Debug.Log("Room ID clicked: " + roomID);
    }

   

    public void RoomQuestClicked()
    {
        PlayerPrefs.SetInt("RoomQuest", roomID);
        SceneManager.LoadScene(roomQuestScene);
        Debug.Log("Room ID clicked: " + roomID);
    }

    public void AddToFavourite()
    {
        const float punchScaleAmount = .5f;
        favouriteButtonTransform.DOPunchScale(new Vector3(punchScaleAmount, punchScaleAmount, 0), animationSpeed);
        isFavouriteButtonPressed = !isFavouriteButtonPressed;
    }

    IEnumerator ResetTab()
    {
        contentTransform.DOLocalMove(resetPosition, animationSpeed);
        bottomNavTransform.DOLocalMove(downUpPosition, animationSpeed);

        yield return new WaitForSeconds(animationSpeed);
    }
}
