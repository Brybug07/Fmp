using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
