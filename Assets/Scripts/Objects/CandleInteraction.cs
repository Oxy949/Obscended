using UnityEngine;
using System.Collections;
using System;

public class CandleInteraction : InteractableObject
{
    private new GameObject light;
    private new GameObject light2;
    public override void Start()
    {
        base.Start();
        //Debug.Log("[CandleInteraction] Start()");
        light = transform.FindChild("2DLight").gameObject;
        light2 = transform.FindChild("Point light").gameObject;
        InteractionStarted += CandleInteraction_InteractionStarted;
        InteractionFinished += CandleInteraction_InteractionFinished;
    }

    private void CandleInteraction_InteractionFinished(object sender, EventArgs e)
    {
        light.SetActive(!light.activeSelf);
        light2.SetActive(!light2.activeSelf);
    }

    private void CandleInteraction_InteractionStarted(object sender, EventArgs e)
    {
        DialogueSystem system = GameObject.FindGameObjectWithTag("Scene").GetComponent<DialogueSystem>();
        system.AddMessage("Хмм... переключатель.", "ТУТ ИМЯ ПЕРСОНАЖА", Resources.LoadAll<Sprite>("Dialogues/hero")[0]);
        system.AddMessage("Тут типа начался интерактивный диалог", "ТУТ ЕЩЕ ИМЯ", Resources.LoadAll<Sprite>("Dialogues/hero")[1]);
        system.AddMessage("Как-то так", "ТУТ ИМЯ ПЕРСОНАЖА", Resources.LoadAll<Sprite>("Dialogues/hero")[2]);
    }
}
