using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReadNoteInteraction : InteractableObject {

	public string text = ""; 
	public bool destroyAfterRead = true;

	public override void Start()
	{
		base.Start();
        InteractionStarted += ReadNoteInteraction_InteractionStarted;
	}

    private void ReadNoteInteraction_InteractionStarted(object sender, EventArgs e)
    {
		NotesSystem system = GameObject.FindWithTag("Scene").GetComponent<NotesSystem>();
        system.AddMessage(text, "Закрыть");

        if (destroyAfterRead)
        {
            this.gameObject.SetActive(false);
        }
    }
}
