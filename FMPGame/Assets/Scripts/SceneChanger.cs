using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] GameObject blackoutImage;
    [SerializeField] private bool blackout;// Set this in the Inspector

    // To be used once added to main scene

    [SerializeField] GameObject tpTo;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject camBrain;

    public void Teleport()
    {
        player.transform.localPosition = tpTo.transform.position;

        cam.transform.localPosition = tpTo.transform.position;

        camBrain.transform.localPosition = tpTo.transform.position;

        if (blackout == true)
        {
            blackoutImage.SetActive(true);
        }
        else
        {
            blackoutImage.SetActive(false);
        }
    }


    //private void Start()
    //{
    //    blackoutImage.SetActive(false);
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Trigger detected"); // Debug log to confirm trigger
    //
    //    if (other.gameObject.tag == "Player") // Ensure the Player GameObject has the "Player" tag
    //    {
    //        Teleport();
    //    }
    //}

    [SerializeField] private string sceneToLoad; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected"); // Debug log to confirm trigger

        if (other.gameObject.tag == "Player") // Ensure the Player GameObject has the "Player" tag
        {
            Debug.Log("Player entered trigger zone. Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
