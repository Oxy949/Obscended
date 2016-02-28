using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MSMessage
{
    public string text;
    public string buttontext;
    public MSMessage(string text, string buttontext)
    {
        this.text = text;
        this.buttontext = buttontext;
    }
}

public class NotesSystem : MonoBehaviour {

    public GameObject message;
    private GameObject noteMessageInstantiate;
    private GameObject dialodMessageInstantiate;
    public bool isShowing = false;
    private List<MSMessage> list;

    // Use this for initialization
    void Start () {
        //window.SetActive(isShowing);
        list = new List<MSMessage>() { };

        noteMessageInstantiate = Instantiate(message) as GameObject;
        noteMessageInstantiate.name = "Canvas-MessageSystem";

        if (GameObject.Find("Canvas"))
        {
            //Log ("Using default canvas");
            noteMessageInstantiate.transform.SetParent(GameObject.Find("Canvas").transform);
        }

        noteMessageInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        noteMessageInstantiate.transform.localScale = new Vector3(1, 1, 1);

        noteMessageInstantiate.SetActive(isShowing);
    }

    public void InvokeCode(string code)
    {
        if (code == "OK")
            HideMessage();
    }

    public void AddMessage(string text, string buttontext)
    {
        list.Add(new MSMessage(text, buttontext));
    }

    public void AddMessage(MSMessage message)
    {
        list.Add(message);
    }

    public void ShowMessage(string text, string buttontext)
    {
        noteMessageInstantiate.transform.FindChild("MessageText").GetComponent<Text>().text = text;
        noteMessageInstantiate.transform.FindChild("MessageButton").GetComponentInChildren<Text>().text = buttontext;
        isShowing = true;

        noteMessageInstantiate.transform.FindChild("MessageButton").GetComponent<Button>().Select();
        noteMessageInstantiate.SetActive(isShowing);
    }

    public void HideMessage()
    {
        //Time.timeScale = 1;
        /*windowInstantiate.transform.FindChild("MessageText").GetComponent<Text>().text = text;
        windowInstantiate.transform.FindChild("MessageButton").GetComponentInChildren<Text>().text = buttontext;*/
        isShowing = false;
        noteMessageInstantiate.SetActive(isShowing);
    }

    // Update is called once per frame
    void Update ()
    {
	    if (!isShowing)
        {
            if (list.Count > 0)
            {
                MSMessage message = list[0];
                ShowMessage(message.text, message.buttontext);
                list.RemoveAt(0);
            }
        }
        else
            noteMessageInstantiate.transform.FindChild("MessageButton").GetComponent<Button>().Select();
    }
}
