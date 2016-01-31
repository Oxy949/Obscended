using UnityEngine;
using System.Collections;

public class ScenesJunction : InteractableObject
{
    public string sceneName = "";
    SceneLoader loader;

    private void Awake()
    {
        loader = GameObject.Find("Scene").GetComponent<SceneLoader>();
    }

    public override void OnObjectNear()
    {
        loader.LoadScene(sceneName);
    }
}
