using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadNoteInteraction : InteractableObject {

	public string text = ""; 
	public bool destroyAfterRead = true;
	public string conditionName = "";
	public string textAfterTrigger = "";

	public override void Start()
	{
		base.Start();
	}

	public override void OnInteraction()
	{
		base.OnInteraction();
		NotesSystem system = GameObject.Find("Scene").GetComponent<NotesSystem>();
		SceneTriggers triggers = GameObject.Find("Scene").GetComponent<SceneTriggers>();

		if (triggers.isConditionCompleated (conditionName) && conditionName != "")
			system.AddMessage (textAfterTrigger, "Закрыть");
		else 
			system.AddMessage (text, "Закрыть");
		
		if (destroyAfterRead) {
			this.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	public override void OnInteractionFinished() {
		base.OnInteractionFinished();
		//Debug.Log("[CandleInteraction] OnInteraction()");

	}

}
