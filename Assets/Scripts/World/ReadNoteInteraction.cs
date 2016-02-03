using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadNoteInteraction : InteractableObject {

	public string text = ""; 
	public bool destroyAfterRead = true;

	public override void Start()
	{
		base.Start();
		Debug.Log ("0");
	}

	public override void OnInteraction()
	{
		base.OnInteraction();
		MessageSystem system = GameObject.Find("Scene").GetComponent<MessageSystem>();
		Debug.Log ("1");
		//Получаем индекс записки из названия и выводим сообщение
		system.AddMessage(text, "Закрыть");
		if (destroyAfterRead) {
			this.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	public override void OnInteractionFinished() {
		base.OnInteraction();
		//Debug.Log("[CandleInteraction] OnInteraction()");

	}

}
