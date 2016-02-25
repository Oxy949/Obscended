using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReadNoteInteraction : InteractableObject {

	public string text = ""; 
	public bool destroyAfterRead = true;

    public bool useTrigger = true;
    public string conditionName = "";
	public string textAfterTrigger = "";

	public override void Start()
	{
		base.Start();
        InteractionStarted += ReadNoteInteraction_InteractionStarted;
	}

    private void ReadNoteInteraction_InteractionStarted(object sender, EventArgs e)
    {
        NotesSystem system = GameObject.Find("Scene").GetComponent<NotesSystem>();
        if (useTrigger)
        {
            SceneTriggers triggers = GameObject.Find("Scene").GetComponent<SceneTriggers>();

            if (triggers.isConditionCompleated(conditionName) && conditionName != "")
                system.AddMessage(textAfterTrigger, "Закрыть");
            else
                system.AddMessage(text, "Закрыть");
        }
        else
            system.AddMessage(text, "Закрыть");

        if (destroyAfterRead)
        {
            this.gameObject.SetActive(false);
        }
    }
}
