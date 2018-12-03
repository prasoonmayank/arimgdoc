using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenScript : MonoBehaviour {

    public GameObject accountScreen;
    public GameObject menuScreen;
    public GameObject profileScreen;
    public GameObject docScreen;

    public void LoggedIn ()
    {
        accountScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
