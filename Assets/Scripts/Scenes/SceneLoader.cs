using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string sceneName)
    {
        if (sceneName == "/reload")
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

        SceneManager.LoadScene(sceneName);
    }
}
