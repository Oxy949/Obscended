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

public class MessageSystem : MonoBehaviour {

    public GameObject window;
    private GameObject windowInstantiate;
    public bool isShowing = false;
    private List<MSMessage> list;

    // Use this for initialization
    void Start () {
        //window.SetActive(isShowing);
        list = new List<MSMessage>() { };

        windowInstantiate = Instantiate(window) as GameObject;
        windowInstantiate.name = "Canvas-MessageSystem";

        if (GameObject.Find("Canvas"))
        {
            //Log ("Using default canvas");
            windowInstantiate.transform.SetParent(GameObject.Find("Canvas").transform, true);
        }

        windowInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        windowInstantiate.transform.localScale = new Vector3(1, 1, 1);

        windowInstantiate.SetActive(isShowing);
    }

    public void InvokeCode(string code)
    {
        if (code == "OK")
            HideMessage();
    }

    public void Test()
    {
        AddMessage("Тест модульных диалогов\nПереход на новую строчку.", "OK");
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
        windowInstantiate.transform.FindChild("MessageText").GetComponent<Text>().text = text;
        windowInstantiate.transform.FindChild("MessageButton").GetComponentInChildren<Text>().text = buttontext;
        isShowing = true;
        windowInstantiate.SetActive(isShowing);
        windowInstantiate.transform.FindChild("MessageButton").GetComponent<Button>().Select();
    }

    public void HideMessage()
    {
        //Time.timeScale = 1;
        /*windowInstantiate.transform.FindChild("MessageText").GetComponent<Text>().text = text;
        windowInstantiate.transform.FindChild("MessageButton").GetComponentInChildren<Text>().text = buttontext;*/
        isShowing = false;
        windowInstantiate.SetActive(isShowing);
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
	}
}
