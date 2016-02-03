using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneConditionTrigerObject : InteractableObject {
    public string conditionName = "";
    public bool isTrigger = false;
	public bool destroyAfterInteraction = true;

    private bool lastState = false;

	public override void Start()
	{
		base.Start();
	}

	public override void OnInteraction()
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
        

        if (destroyAfterInteraction) {
			this.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	public override void OnInteractionFinished()
	{
		base.OnInteractionFinished();

	}

}
