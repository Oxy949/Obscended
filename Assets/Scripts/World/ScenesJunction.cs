using UnityEngine;
using System.Collections;

public class ScenesJunction : InteractableObject
{
    public string sceneID = "";
    SceneLoader loader;

    private void Awake()
    {
        loader = GameObject.Find("Scene").GetComponent<SceneLoader>();
    }

    public override void OnObjectNear()
    {
        loader.LoadScene(sceneID);
    }
}
