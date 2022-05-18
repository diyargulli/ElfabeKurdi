using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRegistration : MonoBehaviour {
	protected string DeviceId;
	protected string plText;
	public GameObject panel; 
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		DeviceId=PlayerPrefs.GetString ("DeviceId");
		plText = PlayerPrefs.GetString ("plText");
		if (plText ==DeviceId && plText != "" ) {
			
			panel.SetActive (false);
			
			//specialMessage.text = " hi Dear \nThis Is a Special Version of the app \nfor you please dont share because it's under developement \nthank you!";
		} else {

			panel.SetActive (true);
			//specialMessage.text = " hi Dear \nThis Is Special Version of the app \nfor you please dont share because it's under developement \nthank you!";

			}

	}
	public void NextNum(){
	//	if (int.Parse (numberTxt.text) <= 34) {
	//	number++;
			//numberTxt.text = (int.Parse(numberTxt.text)+1).ToString();
	//	}

	}
	public void PreviusNum(){

	//	number--;
	//	if (int.Parse (numberTxt.text) >1) {
	//		numberTxt.text = (int.Parse(numberTxt.text)+1).ToString();
	//	}
	
	}
}
