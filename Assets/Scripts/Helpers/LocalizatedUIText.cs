using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;
//using Steamworks;
using System;

public class LocalizatedUIText : MonoBehaviour {
    public string key;
    public bool useCaps = true;
    Text text;
    LanguageManager lmanager;

    // Use this for initialization
    void Start () {
        lmanager = LanguageManager.Instance;
        string lang = "en";
        try
        {
            //lang = SteamApps.GetCurrentGameLanguage().Substring(0, 2);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

        lmanager.ChangeLanguage(lang);
        text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!useCaps)
            text.text = lmanager.GetTextValue(key);
        else
            text.text = lmanager.GetTextValue(key).ToUpper();
    }
}
