using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUnmute : MonoBehaviour {
	public GameObject mute;
	GameObject obj;
	// Use this for initialization
	void Start () {
		mute.SetActive (false);
		obj = GameObject.FindGameObjectWithTag ("music");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Muteunmute(){
		

		if (!mute.gameObject.activeInHierarchy) {
			mute.SetActive (true);
			obj.SetActive (false);
		} else {
			mute.SetActive (false);
			obj.SetActive (true);
		}


	}
}
