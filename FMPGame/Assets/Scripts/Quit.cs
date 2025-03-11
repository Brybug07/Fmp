using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void Quit()
    {
        // If we are running the game in the editor, stop playing the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Otherwise, quit the game (this won't work in the editor)
            Application.Quit();
#endif
    }
}

