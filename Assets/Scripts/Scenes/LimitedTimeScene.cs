using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimitedTimeScene : MonoBehaviour
{
    public float timeRemaining = 60f;
    public GameObject remainingTimeText;
    public bool hasElapsed = false;

    void Start()
    {
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
    }

    void Update()
    {
        if (timeRemaining == 0 && !hasElapsed)
        {
            SendMessageUpwards("timeElapsed");
        }
        else
            remainingTimeText.GetComponent<Text>().text = "" + (int)timeRemaining;

    }

    void decreaseTimeRemaining()
    {
        timeRemaining--;
    }

    //may not be needed, left it in there
    void timeElapsed()
    {
        Debug.Log("[LimitedTimeScene] Time elapsed!");
        MessageSystem system = GameObject.Find("Scene").GetComponent<MessageSystem>();
        system.AddMessage("Время вышло!", "OK");
        CancelInvoke();
        hasElapsed = true;
    }

}