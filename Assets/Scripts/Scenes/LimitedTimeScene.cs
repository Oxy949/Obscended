using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimitedTimeScene : MonoBehaviour
{
    public float timeRemaining = 60f;
    public GameObject remainingTimeText;
    public bool hasElapsed = false;

    public virtual void Start()
    {
        InvokeRepeating("DecreaseTimer", 1.0f, 1.0f);
    }

    public virtual void Update()
    {
        if (timeRemaining == 0 && !hasElapsed)
        {
            SendMessageUpwards("timeElapsed");
        }
        else
            remainingTimeText.GetComponent<Text>().text = "" + (int)timeRemaining;

    }

    public virtual void DecreaseTimer()
    {
        timeRemaining--;
    }

    //may not be needed, left it in there
    public virtual void timeElapsed()
    {
        Debug.Log("[LimitedTimeScene] Time elapsed!");
        NotesSystem system = GameObject.FindGameObjectWithTag("Scene").GetComponent<NotesSystem>();
        transform.FindChild("TimerSound").GetComponent<AudioSource>().Stop();
        system.AddMessage("Время вышло!", "OK");
        CancelInvoke();
        hasElapsed = true;
    }

    public virtual void onAllConditionsCompleated()
    {
        Debug.Log("[LimitedTimeScene] All conditions compleated!");
        CancelInvoke();
        transform.FindChild("TimerSound").GetComponent<AudioSource>().Stop();
    }
}