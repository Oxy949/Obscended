using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadNoteInteraction : InteractableObject {

//	private new GameObject light;
	public override void Start()
	{
		base.Start();
		Debug.Log("[CandleInteraction] Start()");
//		light = transform.FindChild("2DLight").gameObject;
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
		Debug.Log("[CandleInteraction] OnInteraction()");
//		light.SetActive(!light.activeSelf);
	}


	/*public List<string> l_notesWords = new List<string>(); 

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
		system.AddMessage(l_notesWords[int.Parse(gameObject.name.Substring(gameObject.name.LastIndexOf('_') + 1))], "Закрыть");
	}

	// Update is called once per frame
	public override void OnInteractionFinished() {
		base.OnInteraction();
		//Debug.Log("[CandleInteraction] OnInteraction()");

	}*/

}
