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
    public bool isCompleated = false;

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

        if (allCompleated && isCompleated == false)
        {
            LimitedTimeScene scene = GameObject.Find("Scene").GetComponent<LimitedTimeScene>();
            isCompleated = true;
            scene.onAllConditionsCompleated();
        }
    }

    public void SetCondition(string name, bool value)
    {
        foreach (Condition c in conditions)
        {
            if (c.name == name)
            {
                isCompleated = false;
                c.isCompleated = value;
            }
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
