using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceStartAndEnd : MonoBehaviour {
	public int completed=0;
	void Start(){
	 completed=0;
	}
	void Update(){
		

		PlayerPrefs.SetInt ("completed", completed);
		Debug.Log (completed + "comp");
		if( completed==1)
			completed=0;
	}
	void OnMouseEnter(){
		Debug.Log ("mouse entered TraceS&E");

	}

	void OnMouseExit(){
		Debug.Log ("mouse exit TraceS&E");
	}
	void OnTriggerEnter2D(Collider2D other){	Debug.Log ("colllider entered TraceS&E");
	//	PlayerPrefs.SetInt ("completed", 1);
		completed=1;
	}
	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("colllider entered TraceS&E");
		PlayerPrefs.SetInt ("completed", 0);
		completed=0;
	}
	void OnMouseUp(){
		completed = 0;
	}
	void OnMouseDown(){
		Debug.Log ("moused Up ");
		//completed = 0;
	}
}
