using UnityEngine;
using System.Collections;

public enum MessageSystems { Nsystem, Dsystem };

public class MessageSystemButton : MonoBehaviour {
    public MessageSystems system;
    NotesSystem nsystem;
    DialogueSystem dsystem;
    // Use this for initialization
    void Start () {
        if (system == MessageSystems.Dsystem)
            dsystem = GameObject.FindGameObjectWithTag("Scene").GetComponent<DialogueSystem>();

        if (system == MessageSystems.Nsystem)
            nsystem = GameObject.FindGameObjectWithTag("Scene").GetComponent<NotesSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendAction(string actionCode)
    {
        if (system == MessageSystems.Dsystem)
            dsystem.InvokeCode("OK");

        if (system == MessageSystems.Nsystem)
            nsystem.InvokeCode("OK");
    }
}
