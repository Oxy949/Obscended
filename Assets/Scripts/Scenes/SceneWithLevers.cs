using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;

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
    public int maxPuzzleHistory = 2;
    public int maxLampsPerLever = 3;

    //Logic
    private List<AdvLever> levers;
    private List<bool> lamps;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        lamps = new List<bool>() { };

        for (int i=0; i< lampsList.Count; i++)
        {
            lamps.Add(true);
        }

        Debug.Log("[SceneWithLevers] Total lamps found:" + lamps.Count);

        levers = new List<AdvLever>() { };

        /* Старый алгоритм
        for (int i = 0; i < leversList.Count; i++)
        {
            List<int> forLamps = new List<int> { };

            int lampsLeft = maxLampsPerLever;
            int id = 0;
            for (int j = 0; j < lampsList.Count; j++)
            {
                //if (id == leversList.IndexOf(lever))
                int useLamp = 0;
                if (lampsLeft > 0)
                    useLamp = UnityEngine.Random.Range(0, 2);
                forLamps.Add(useLamp);
                if (useLamp == 1)
                    lampsLeft--;
                id++;
            }

            if (lampsLeft == maxLampsPerLever)
            {
                int fixLampId = UnityEngine.Random.Range(0, lampsList.Count);
                forLamps[fixLampId] = 1;
            }
                

            levers.Add(new AdvLever(forLamps, false));
        }*/

        // Новый
        List<int> usedLamps = new List<int>() { };
        for (int i = 0; i < leversList.Count; i++)
        {
            List<int> forLamps = new List<int> { };

            int lampToAddId = UnityEngine.Random.Range(0, lampsList.Count);
            while (usedLamps.Any(item => item == lampToAddId))
            {
                lampToAddId = UnityEngine.Random.Range(0, lampsList.Count);
            }

            usedLamps.Add(lampToAddId);

            for (int j = 0; j < lampsList.Count; j++)
            {
                int useLamp = 0;
                if (lampToAddId == j)
                    useLamp = 1;
                forLamps.Add(useLamp);
            }

            levers.Add(new AdvLever(forLamps, false));
        }

        for (int i = 0; i < leversList.Count; i++)
        {

            int lampsLeft = maxLampsPerLever-1;
            for (int j = 0; j < lampsList.Count; j++)
            {
                //if (id == leversList.IndexOf(lever))
                if (lampsLeft > 0 && levers[i].lampsId[j] == 0)
                {
                    levers[i].lampsId[j] = UnityEngine.Random.Range(0, 2);
                }
                    
                if (levers[i].lampsId[j] == 1)
                    lampsLeft--;
            }
        }

        Debug.Log("[SceneWithLevers] Total levers found:" + levers.Count);

        //PrintLeversMap();

        MixPuzzle();

        UpdateLevers();
    }

    public void PrintLampsMap()
    {
        Debug.Log("Current lamps stats:");
        for (int i = 0; i < lamps.Count; i++)
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
            for (int i = 0; i < lever.lampsId.Count; i++)
                Debug.Log(lever.lampsId[i]);
            Debug.Log("------------------------------------");
        }
    }

    public void MixPuzzle()
    {
        Debug.Log("Mix puzzle with " + maxPuzzleSteps + " steps");

        string solution = "";

        /* Старый алгоритм
        for (int i = 0; i < maxPuzzleSteps; i++)
        {
            int currentLeverId = UnityEngine.Random.Range(0, levers.Count);
            solution += currentLeverId;
            solution += ",";
            TriggerLever(currentLeverId, false);
        }
        while (isAllLampsActive())
        {
            int currentLeverId = UnityEngine.Random.Range(0, levers.Count);
            solution += currentLeverId;
            solution += ",";
            TriggerLever(currentLeverId, false);
        }*/

        //TODO: Все еще так себе!
        //Новый алоритм
        if (maxPuzzleHistory > levers.Count-1)
            maxPuzzleHistory = levers.Count-1;
        List<int> lastLaverId = new List<int>() { };
        int currentLeverId = UnityEngine.Random.Range(0, levers.Count);

        for (int i = 0; i < maxPuzzleSteps; i++)
        {
            if (lastLaverId.Count > maxPuzzleHistory)
            {
                lastLaverId.RemoveAt(0);
            }

            int maxinteractions = int.MaxValue;
            while (lastLaverId.Any(item => item == currentLeverId) && maxinteractions>0)
            {
                currentLeverId = UnityEngine.Random.Range(0, levers.Count);
                maxinteractions--;
            }
            TriggerLever(currentLeverId, false);
            lastLaverId.Add(currentLeverId);

            /*
            string inList = "";
            foreach (int t in lastLaverId)
            {
                inList += t + ";";
            }
            Debug.Log(inList);*/

            if (!isAllLampsActive())
            {
                solution += currentLeverId;
                solution += ",";
            }
            else
            {
                TriggerLever(currentLeverId, false);
            }
            
        }

        UpdateLevers();

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

        for (int i = 0; i < lever.lampsId.Count; i++)
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

            lamp.transform.GetChild(0).gameObject.SetActive(lamps[id]);
            id++;
        }

        //PrintLampsMap();
    }

    bool isAllLampsActive()
    {
        bool allEnabled = true;
        int id = 0;
        for (int i = 0; i < lampsList.Count; i++)
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
