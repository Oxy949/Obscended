using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LeverInteraction : InteractableObject
{
    public int id = 0;
    SceneWithLevers scene;
    SpriteRenderer img;

    public override void Start()
    {
        base.Start();
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneWithLevers>();
        img = GetComponent<SpriteRenderer>();
        InteractionFinished += LeverInteraction_InteractionFinished;
    }

    private void LeverInteraction_InteractionFinished(object sender, EventArgs e)
    {
        Sprite newSprite = scene.TriggerLever(id);
        img.sprite = newSprite;
    }
}