using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel; // Assign in Inspector
    public Button popupButton;    // Assign in Inspector

    void Start()
    {
        if (popupPanel == null)
        {
            Debug.LogError("Popup Panel is not assigned!");
            return;
        }

        if (popupButton == null)
        {
            Debug.LogError("Popup Button is not assigned!");
            return;
        }

        popupPanel.SetActive(false);
        popupButton.onClick.AddListener(ShowPopup);
    }

    void ShowPopup()
    {
        Debug.Log("Button clicked, showing popup!");
        popupPanel.SetActive(true);
    }
}
