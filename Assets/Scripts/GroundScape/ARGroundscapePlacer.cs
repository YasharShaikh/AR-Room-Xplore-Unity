using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARGroundscapePlacer : MonoBehaviour
{

    [SerializeField] RoomSo roomSo;
    [Header("Animation")]
    [SerializeField] float animationSpeed;
    [SerializeField] float animationDistance;
    [SerializeField] float timeToDisable;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [Space]
    [SerializeField] GameObject HowToInstruction;
    [SerializeField] RectTransform scanGroundMobile;
    [SerializeField] RectTransform scanGroundFloor;
    [SerializeField] GameObject placementIndicator;
    [Space]
    [SerializeField] GameObject GroundScapeDescription;
    GameObject holder;
    Sequence instructionSequence;
    GameObject spawnedObject;
    Pose placementPose;
    ARRaycastManager raycastManager;
    bool loadedFirstTime;

    bool placementPoseIsValid = false;
    bool roomSpawned = false;

    private void Awake()
    {
        Initialization();
        loadedFirstTime = true;
    }

    void Start()
    {
        roomSpawned = false;
    }

    void Update()
    {
        if (loadedFirstTime)
        {
            StartCoroutine(ShowDescription());
        }
        else
        {
            if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                PlaceObject();
            }

            UpdatePlacementPose();
            UpdatePlacementIndicator();

        }



    }

    private void UpdatePlacementIndicator()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(.5f, .5f));
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            DisableShowHowToInstruction();
            placementPose = hits[0].pose;
        }
    }

    private void UpdatePlacementPose()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            if (instructionSequence == null || !instructionSequence.IsPlaying())
            {
                ShowHowToInstruction();
            }
        }
    }

    void PlaceObject()
    {
        if(roomSo!=null)
        {
            spawnedObject = Instantiate(roomSo.roomPrefab,placementPose.position, placementPose.rotation);
        }

        //switch (groundQuestID)
        //{
        //    case 1:
        //        spawnedObject = Instantiate(roomPrefabs[0], placementPose.position, placementPose.rotation);
        //        break;

        //    case 2:
        //        spawnedObject = Instantiate(roomPrefabs[1], placementPose.position, placementPose.rotation);
        //        break;

        //    case 3:
        //        spawnedObject = Instantiate(roomPrefabs[2], placementPose.position, placementPose.rotation);
        //        break;

        //    case 4:
        //        spawnedObject = Instantiate(roomPrefabs[2], placementPose.position, placementPose.rotation);
        //        break;
        //}

        if (spawnedObject != null)
        {
            // Attach ARAnchor component to maintain its position in the real world
            ARAnchor arAnchor = spawnedObject.AddComponent<ARAnchor>();
            if (arAnchor != null)
            {
                // Anchor the spawned object in the AR space
                arAnchor.transform.position = placementPose.position;
                arAnchor.transform.rotation = placementPose.rotation;
            }
            placementIndicator.SetActive(false);
        }
    }

    private void Initialization()
    {
        holder = null;
        raycastManager = GetComponent<ARRaycastManager>();

    }

    private void ShowHowToInstruction()
    {
        HowToInstruction.SetActive(true);
        Vector3 upPosition = scanGroundMobile.anchoredPosition + (Vector2.up * animationDistance);
        Vector3 downPosition = scanGroundMobile.anchoredPosition;

        instructionSequence = DOTween.Sequence();
        instructionSequence.Append(scanGroundMobile.DOAnchorPos(upPosition, animationSpeed * 0.5f).SetEase(Ease.OutQuad));
        instructionSequence.Append(scanGroundMobile.DOAnchorPos(downPosition, animationSpeed * 0.5f).SetEase(Ease.InQuad));
        instructionSequence.SetLoops(-1);
    }

    private void DisableShowHowToInstruction()
    {
        HowToInstruction?.SetActive(false);
        StartCoroutine(WaitTimer());
        instructionSequence.Kill();
        HowToInstruction.SetActive(false);
    }

    private IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(timeToDisable);
    }
    private IEnumerator ShowDescription()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("SCreen touches");
            GroundScapeDescription.SetActive(false);
            loadedFirstTime = false;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            GroundScapeDescription.SetActive(false);
            loadedFirstTime = false;
        }
    }
    /// <summary>
    /// Button functions
    /// </summary>
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetAROBJButton()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }

}
