using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneConditionTrigerObject : InteractableObject {
    public string conditionName = "";
    public bool isTrigger = false;
	public bool destroyAfterInteraction = true;
	public bool rotateAfterInteraction = false;

    public bool showDialogue = false;
    public string message = "";
    public string messageSender = "";
    public Sprite senderImage;

    private bool lastState = false;

	public override void Start()
	{
		base.Start();
	}

	/*public override void OnInteraction()
	{
		base.OnInteraction();
        SceneTriggers triggers = GameObject.Find("Scene").GetComponent<SceneTriggers>();
        if (isTrigger)
        {
            triggers.SetCondition(conditionName, !triggers.isConditionCompleated(conditionName));
        }
            else
        {
            triggers.SetCondition(conditionName, true);
        }
        
		if (rotateAfterInteraction) {
			this.gameObject.transform.Rotate(this.gameObject.transform.rotation.x,this.gameObject.transform.rotation.y,this.gameObject.transform.rotation.z + 180);
		}

        if (destroyAfterInteraction) {
			this.gameObject.SetActive (false);
		}

        if (showDialogue)
        {
            DialogueSystem system = GameObject.Find("Scene").GetComponent<DialogueSystem>();
            system.AddMessage(message, messageSender, senderImage);
        }
	}

	// Update is called once per frame
	public override void OnInteractionFinished()
	{
		base.OnInteractionFinished();

	}*/

}
