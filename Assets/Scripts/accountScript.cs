using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class accountScript : MonoBehaviour {

    public screenScript mainCanvas;

    public GameObject LoginPanel;
    public GameObject RegisterPanel;

    public GameObject LoginUN;
    public GameObject LoginPwd;
    public Text Loginwarning;
    private string loginun;
    private string loginpwd;

    public GameObject RegisterUN;
    public GameObject RegisterPwd;
    public GameObject RegistercPwd;
    public Text RegisterWarning;
    private string registerun;
    private string registerpwd;
    private string registercpwd;

    public TextAsset accounts;
    private string[] rows;
    private string[] usernames;
    private string[] passwords;

    public void ToggleLogin()
    {
        if (!LoginPanel.activeSelf)
        {
            LoginPanel.SetActive(!LoginPanel.activeSelf);
            RegisterPanel.SetActive(!RegisterPanel.activeSelf);
        }
    }

    public void ToggleRegister()
    {
        if (!RegisterPanel.activeSelf)
        {
            RegisterPanel.SetActive(!RegisterPanel.activeSelf);
            LoginPanel.SetActive(!LoginPanel.activeSelf);
        }
    }

    // Use this for initialization
    void Start () {
        rows = accounts.text.Split("\n"[0]);
        usernames = new string[rows.Length];
        passwords = new string[rows.Length];
        for(int i=0; i<rows.Length; i++)
        {
            string[] parts = rows[i].Split(","[0]);
            usernames[i] = parts[0];
            passwords[i] = parts[1].Substring(0,parts[1].Length-1);
        }
	}

    public void LoginFunction ()
    {
        int i = 0;
        loginun = LoginUN.GetComponent<InputField>().text;
        loginpwd = LoginPwd.GetComponent<InputField>().text;
        for(i=0; i<usernames.Length; i++)
        {
            if(loginun == usernames[i])
            {
                if(loginpwd == passwords[i])
                {
                    Debug.LogWarning("Successfully logged in");
                    mainCanvas.LoggedIn();
                }
                else
                {
                    Debug.LogWarning("Incorrect Password");
                }
                break;
            }
        }
        if(i==usernames.Length)
        {
            Debug.LogWarning("Sorry, I dont recognize this. Please register");
        }
    }

    public void RegisterFunction ()
    {
        registerun = RegisterUN.GetComponent<InputField>().text;
        registerpwd = RegisterPwd.GetComponent<InputField>().text;
        registercpwd = RegistercPwd.GetComponent<InputField>().text;
        string registerrow = registerun + "," + registerpwd + "\n";
        string newtext = accounts.text + registerrow;

        StreamWriter accountsText = new StreamWriter("Assets/Account/account.csv");
        accountsText.Write(newtext);
        Debug.LogWarning("Registration Successful");
        accountsText.Close();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
