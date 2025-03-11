using UnityEngine;
using UnityEngine.SceneManagement;  // Required to work with scenes

public class ChangeScene : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void LoadScene(string sceneName)
    {
        // Check if the scene is included in the build settings
        if (IsSceneInBuildSettings(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " does not exist in the build settings.");
        }
    }

    // Helper function to check if a scene is in the build settings
    private bool IsSceneInBuildSettings(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameFromPath = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            if (sceneNameFromPath == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
