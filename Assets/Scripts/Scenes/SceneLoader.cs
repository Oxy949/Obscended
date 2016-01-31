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

    public void LoadScene(string sceneId)
    {
        if (sceneId == "/reload")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (sceneId != "/exit")
            SceneManager.LoadScene(sceneId);
        else {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }
    }
}
