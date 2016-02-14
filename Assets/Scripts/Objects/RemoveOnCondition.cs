using UnityEngine;
using System.Collections;

public class RemoveOnCondition : MonoBehaviour {

    public string conditionName = "";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SceneTriggers triggers = GameObject.Find("Scene").GetComponent<SceneTriggers>();

        if (triggers.isConditionCompleated(conditionName))
            this.gameObject.SetActive(false);
    }
}
