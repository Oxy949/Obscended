using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeverInteraction : InteractableObject
{
    public int id = 0;
    SceneWithLevers scene;
    SpriteRenderer img;

	public override void Start ()
    {
        base.Start();
        scene = GameObject.Find("Scene").GetComponent<SceneWithLevers>();
        img = GetComponent<SpriteRenderer>();
    }

    public override void Update ()
    {
        base.Update();
    }

    public override void OnInteractionFinished()
    {
        base.OnInteractionFinished();
        Sprite newSprite = scene.TriggerLever(id);
        img.sprite = newSprite;
    }
}
