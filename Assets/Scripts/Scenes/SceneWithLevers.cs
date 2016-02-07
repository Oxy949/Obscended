using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System;

public class AdvLever
{
    public List<int> lampsId;
    public bool isActive = false;

    public AdvLever(List<int> lampsId, bool isActive)
    {
        this.lampsId = lampsId;
        this.isActive = isActive;
    }
}

public class SceneWithLevers : LimitedTimeScene
{
    //For editor
    public List<GameObject> leversList;
    public List<GameObject> lampsList;

    public Sprite levelSpriteOff;
    public Sprite levelSpriteOn;

    public Sprite lampSpriteOff;
    public Sprite lampSpriteOn;

    public int maxPuzzleSteps = 5;

    //Logic
    private List<AdvLever> levers;
    private List<bool> lamps;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        lamps = new List<bool>() { };

        foreach (GameObject lamp in lampsList)
        {
            lamps.Add(true);
        }

        Debug.Log("[SceneWithLevers] Total lamps found:" + lamps.Capacity);


        levers = new List<AdvLever>() { };

        foreach (GameObject lever in leversList)
        {
            List<int> forLamps = new List<int> { };

            int id = 0;
            foreach (GameObject lamp in lampsList)
            {
                //if (id == leversList.IndexOf(lever))
                forLamps.Add(UnityEngine.Random.Range(0,2));
                id++;
            }

            levers.Add(new AdvLever(forLamps, false));
        }

        Debug.Log("[SceneWithLevers] Total levers found:" + levers.Capacity);

        UpdateLevers();

        //PrintLeversMap();

        MixPuzzle();
    }

    public void PrintLampsMap()
    {
        Debug.Log("Current lamps stats:");
        for (int i = 0; i < lamps.Capacity; i++)
        {
            Debug.Log("-------------- Lamp " + i + "--------------");
            Debug.Log("Enabled: " + lamps[i]);
            Debug.Log("------------------------------------");
        }
    }

    public void PrintLeversMap()
    {
        Debug.Log("Current lever map:");
        foreach (AdvLever lever in levers)
        {
            Debug.Log("------------- Lever " + levers.IndexOf(lever) + "-------------");
            Debug.Log("Enabled: " + lever.isActive);
            for (int i = 0; i < lever.lampsId.Capacity; i++)
                Debug.Log(lever.lampsId[i]);
            Debug.Log("------------------------------------");
        }
    }

    public void MixPuzzle()
    {
        Debug.Log("Mix puzzle with " + maxPuzzleSteps + " steps");

        string solution = "";
        for (int i = 0; i < maxPuzzleSteps; i++)
        {
            int currentLeverId = UnityEngine.Random.Range(0, levers.Capacity);
            solution += currentLeverId;
            solution += ",";
            TriggerLever(currentLeverId, false);
        }
        while (isAllLampsActive())
        {
            int currentLeverId = UnityEngine.Random.Range(0, levers.Capacity);
            solution += currentLeverId;
            solution += ",";
            TriggerLever(currentLeverId, false);
        }

        Debug.Log("Solution: " + solution);

        //PrintLeversMap();
        UpdateLamps();
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
    }

    public Sprite TriggerLever(int id, bool checkResult = true)
    {
        AdvLever lever = levers[id];

        lever.isActive = !lever.isActive;
        //lamps[id] = !lamps[id];

        for (int i = 0; i < lever.lampsId.Capacity; i++)
        {
            if (lever.lampsId[i] == 1)
            {
                lamps[i] = !lamps[i];
            }
        }

        UpdateLamps();

        if (checkResult)
            CheckResult();

        if (lever.isActive)
            return levelSpriteOn;
        else
            return levelSpriteOff;
    }

    void UpdateLevers()
    {
        foreach (AdvLever lever in levers)
        {
            int id = levers.IndexOf(lever);
            if (lever.isActive)
                leversList[id].GetComponent<SpriteRenderer>().sprite = levelSpriteOn;
            else
                leversList[id].GetComponent<SpriteRenderer>().sprite = levelSpriteOff;
        }
    }

    void UpdateLamps()
    {
        int id = 0;
        foreach (GameObject lamp in lampsList)
        {
            if (lamps[id])
                lamp.GetComponent<SpriteRenderer>().sprite = lampSpriteOn;
            else
                lamp.GetComponent<SpriteRenderer>().sprite = lampSpriteOff;
            id++;
        }

        //PrintLampsMap();
    }

    bool isAllLampsActive()
    {
        bool allEnabled = true;
        int id = 0;
        foreach (GameObject lamp in lampsList)
        {
            if (!lamps[id])
                allEnabled = false;
            id++;
        }
        return allEnabled;
    }

    void CheckResult()
    {
        if (isAllLampsActive())
            onAllConditionsCompleated();
    }
}
