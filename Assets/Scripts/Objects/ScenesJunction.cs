using UnityEngine;
using System.Collections;
using System;

public class ScenesJunction : InteractableObject
{
    public string sceneName = "";
    SceneLoader loader;

    private void Awake()
    {
        loader = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneLoader>();
        ObjectNear += ScenesJunction_ObjectNear;
    }

    private void ScenesJunction_ObjectNear(object sender, EventArgs e)
    {
        loader.LoadScene(sceneName);
    }

    /*public override void OnObjectNear()
    {
        loader.LoadScene(sceneName);
    }*/
}
