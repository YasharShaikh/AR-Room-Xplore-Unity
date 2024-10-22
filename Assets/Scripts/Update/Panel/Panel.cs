using DG.Tweening;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("UI animation")]
    [SerializeField] RectTransform rectTransform;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float slideDuration = 0.5f;
    [SerializeField] float fadeDuration = 0.3f;

    Vector2 hiddenPosition = new Vector2(0, 0);



    private void Awake()
    {
        rectTransform.anchoredPosition = hiddenPosition;

        canvasGroup.alpha = 0; // Start with invisible panel
    }

    public virtual void Show()
    {
        rectTransform.DOAnchorPos(Vector2.zero, slideDuration).SetEase(Ease.OutCubic);
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1, fadeDuration).OnComplete(() =>
            {
                gameObject.SetActive(true); //Activate after the fade-out animation is completed
            });
        }
        gameObject.SetActive(true); //Activate after the fade-out animation is completed
    }
    public virtual void Hide()
    {
        rectTransform.DOAnchorPos(hiddenPosition, slideDuration).SetEase(Ease.InCubic);
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0, fadeDuration).OnComplete(() =>
            {
                gameObject.SetActive(false); // Deactivate after the fade-out animation is completed
            });
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
