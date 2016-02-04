using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTypingEffect : MonoBehaviour {
    public float speed = 0.05f;
    Text text;
    public bool useOriginalText = true;
    public string message;
    
	// Use this for initialization
	void OnEnable() {
        text = GetComponent<Text>();
        RestartAnimation();
    }

    void Step()
    {
        if (text.text.Length < message.Length)
            text.text += message[text.text.Length];
        else
            CancelInvoke();
    }

    public void RestartAnimation()
    {
        if (useOriginalText)
            message = text.text;
        text.text = "";
        InvokeRepeating("Step", speed, speed);
    }
}
