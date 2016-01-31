using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName.StartsWith("/"))
        {
            if (sceneName == "/reset")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (sceneName == "/exit")
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
            }
        }
        else
            SceneManager.LoadScene(sceneName);
    }
}
