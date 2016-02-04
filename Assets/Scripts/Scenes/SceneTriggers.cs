using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Condition
{
    public string name;
    public bool isCompleated;
}

public class SceneTriggers : MonoBehaviour
{
    public List<Condition> conditions;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool allCompleated = true;
        foreach (Condition c in conditions)
        {
            if (c.isCompleated == false)
                allCompleated = false;
        }

        if (allCompleated)
        {
            LimitedTimeScene scene = GameObject.Find("Scene").GetComponent<LimitedTimeScene>();
            scene.onAllConditionsCompleated();
        }
    }

    public void SetCondition(string name, bool value)
    {
        foreach (Condition c in conditions)
        {
            if (c.name == name)
                c.isCompleated = value;
        }
    }

    public bool isConditionCompleated(string name)
    {
        foreach (Condition c in conditions)
        {
            if (c.name == name)
                return c.isCompleated;
        }

        return false;
    }
}
