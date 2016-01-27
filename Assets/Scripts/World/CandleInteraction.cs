using UnityEngine;
using System.Collections;

public class CandleInteraction : InteractableObject
{
    private new GameObject light;
    public override void Start()
    {
        base.Start();
        //Debug.Log("[CandleInteraction] Start()");
        light = transform.FindChild("2DLight").gameObject;
    }

    public override void OnInteraction()
    {
        base.OnInteraction();
        MessageSystem system = GameObject.Find("Scene").GetComponent<MessageSystem>();
        system.AddMessage("Вы использовали переключатель.", "OK");
    }

    // Update is called once per frame
    public override void OnInteractionFinished() {
        base.OnInteraction();
        //Debug.Log("[CandleInteraction] OnInteraction()");
        light.SetActive(!light.activeSelf);
    }
}
