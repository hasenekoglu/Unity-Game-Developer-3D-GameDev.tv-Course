
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform target;

    [SerializeField] Image playerIcon;
    [SerializeField] Image targetIcon;

    RectTransform canvasRect;
    RectTransform playerIconRect;
    RectTransform targetIconRect;

    void Start()
    {
        canvasRect = GetComponentInParent<RectTransform>();
        playerIconRect = playerIcon.GetComponent<RectTransform>();
        targetIconRect = targetIcon.GetComponent<RectTransform>();
    }

    void Update()
    {
        UpdateMinimap();
    }

    void UpdateMinimap()
    {
        Vector3 playerPosition = player.position;
        Vector3 targetPosition = target.position;

        // Güncel oyuncu ve hedef ikonlarını ayarla
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(playerPosition);
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetPosition);

        // Oyuncu ve hedef ikonlarını minimap içinde sınırla
        playerScreenPos.x = Mathf.Clamp(playerScreenPos.x, canvasRect.rect.min.x, canvasRect.rect.max.x);
        playerScreenPos.y = Mathf.Clamp(playerScreenPos.y, canvasRect.rect.min.y, canvasRect.rect.max.y);
        targetScreenPos.x = Mathf.Clamp(targetScreenPos.x, canvasRect.rect.min.x, canvasRect.rect.max.x);
        targetScreenPos.y = Mathf.Clamp(targetScreenPos.y, canvasRect.rect.min.y, canvasRect.rect.max.y);

        // Oyuncu ve hedef ikonlarını güncelle
        playerIconRect.anchoredPosition = playerScreenPos;//- canvasRect.sizeDelta / 2;
        targetIconRect.anchoredPosition = targetScreenPos;//- canvasRect.sizeDelta / 2;
    }
}
/* {

    [SerializeField] Transform player;
    [SerializeField] Transform landing;



    [SerializeField] Image playerImage;
    [SerializeField] Image landingImage;
    [SerializeField] Image clampedPosition;

    RectTransform canvasRect;
    RectTransform uiElementReact;

    void Start()
    {
        canvasRect = GetComponentInParent<RectTransform>();
        uiElementReact = GetComponent<RectTransform>();

    }
    void Update()
    {
        AngleCalculate();

    }
    void AngleCalculate()
    {
        Vector3 playerPosition = player.position;
        Vector3 landingPosition = landing.position;
        Vector3 distance = playerPosition - landingPosition;
        Debug.Log(distance);


        playerImage.transform.position = playerPosition;
        landingImage.transform.position = landingPosition;

        // UI öğesinin güncellenmiş pozisyonunu sınırlamak için yeni bir vektör oluştur
        Vector3 clampedPosition = uiElementReact.anchoredPosition;

        // X koordinatını Canvas sınırları içinde kısıtla
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, canvasRect.rect.min.x, canvasRect.rect.max.x);

        // Y koordinatını Canvas sınırları içinde kısıtla
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, canvasRect.rect.min.y, canvasRect.rect.max.y);

        // Kısıtlanmış pozisyonu UI öğesinin pozisyonuna uygula
        uiElementReact.anchoredPosition = clampedPosition;


    }

}
 */