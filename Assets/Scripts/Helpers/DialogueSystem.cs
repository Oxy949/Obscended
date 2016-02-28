using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DMessage
{
    public string text;
    public string senderName;
    public Sprite senderImage;
    public DMessage(string text, string senderName, Sprite senderImage)
    {
        this.text = text;
        this.senderName = senderName;
        this.senderImage = senderImage;
    }
}

public class DialogueSystem : MonoBehaviour
{

    public GameObject dialogueMessage;
    private GameObject dialogueMessageInstantiate;
    public bool isShowing = false;
    private List<DMessage> list;

    // Use this for initialization
    void Start()
    {
        //window.SetActive(isShowing);
        list = new List<DMessage>() { };

        dialogueMessageInstantiate = Instantiate(dialogueMessage) as GameObject;
        dialogueMessageInstantiate.name = "Canvas-DialogueSystem";

        if (GameObject.Find("Canvas"))
        {
            //Log ("Using default canvas");
            dialogueMessageInstantiate.transform.SetParent(GameObject.Find("Canvas").transform);
        }

        dialogueMessageInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        dialogueMessageInstantiate.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
        dialogueMessageInstantiate.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        dialogueMessageInstantiate.transform.localScale = new Vector3(1, 1, 1);

        dialogueMessageInstantiate.SetActive(isShowing);
    }

    public void InvokeCode(string code)
    {
        if (code == "OK")
            HideMessage();
    }

    public void AddMessage(string text, string senderName, Sprite senderImage)
    {
        list.Add(new DMessage(text, senderName, senderImage));
    }

    public void ShowMessage(string text, string senderName, Sprite senderImage)
    {
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageText").GetComponent<Text>().text = text;
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageSenderName").GetComponentInChildren<Text>().text = senderName;
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageSenderImage").GetComponentInChildren<Image>().sprite = senderImage;
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageButton").GetComponentInChildren<Text>().text = "Продолжить";

        isShowing = true;
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageButton").GetComponent<Button>().Select();
        dialogueMessageInstantiate.SetActive(isShowing);

        /*dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageText").GetComponent<TextTypingEffect>().RestartAnimation();
        dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageSenderName").GetComponent<TextTypingEffect>().RestartAnimation();*/
    }

    public void HideMessage()
    {
        //Time.timeScale = 1;
        /*windowInstantiate.transform.FindChild("MessageText").GetComponent<Text>().text = text;
        windowInstantiate.transform.FindChild("MessageButton").GetComponentInChildren<Text>().text = buttontext;*/
        isShowing = false;
        dialogueMessageInstantiate.SetActive(isShowing);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowing)
        {
            if (list.Count > 0)
            {
                DMessage message = list[0];
                ShowMessage(message.text, message.senderName, message.senderImage);
                list.RemoveAt(0);
            }
        }
        else
            dialogueMessageInstantiate.transform.FindChild("DialogueSystem").FindChild("MessageButton").GetComponent<Button>().Select();
    }
}
