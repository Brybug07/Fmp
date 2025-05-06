using UnityEngine;
using UnityEngine.UI;

public class PopupOnCollision : MonoBehaviour
{
    public GameObject popupUI;         // UI panel with message + button
    public Button closeButton;       // Reference to the close button
    public Button yesButton;
    private void Start()
    {
        if (popupUI != null)
            popupUI.SetActive(false);

        if (closeButton != null)
            closeButton.onClick.AddListener(HidePopup);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI != null)
                popupUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI.activeSelf == true)
                popupUI.SetActive(false);
        }
    }

    void HidePopup()
    {
        if (popupUI != null)
            popupUI.SetActive(false);

        // Optionally destroy or disable the item after showing
        // gameObject.SetActive(false);
    }
}
