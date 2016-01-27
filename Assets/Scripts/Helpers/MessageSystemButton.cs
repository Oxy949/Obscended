using UnityEngine;
using System.Collections;

public class MessageSystemButton : MonoBehaviour {
    MessageSystem system;
    // Use this for initialization
    void Start () {
        system = GameObject.Find("Scene").GetComponent<MessageSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendAction(string actionCode)
    {
        system.InvokeCode("OK");
    }
}
