using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    public TextAsset textFile;
    private string[] rows;
    private string[] usernames;
    private string[] passwords;

    public void seetext ()
    {
        Debug.LogWarning(textFile.text);
        rows = textFile.text.Split("\n"[0]);
        usernames = new string[rows.Length];
        passwords = new string[rows.Length];
        for(int i=0; i<rows.Length; i++)
        {
            string[] parts = rows[i].Split(","[0]);
            usernames[i] = parts[0];
            passwords[i] = parts[1];
        }
        for (int i=0;i<usernames.Length;i++)
        {
            Debug.LogWarning(usernames[i]);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
