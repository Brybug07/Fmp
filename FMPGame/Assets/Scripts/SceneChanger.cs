using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Set this in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name); // Debug log to confirm trigger

        if (other.CompareTag("Player")) // Ensure the Player GameObject has the "Player" tag
        {
            Debug.Log("Player entered trigger zone. Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
