using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracing : MonoBehaviour {

	public string trace;
	public static float fillAmount;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetString ("trace",trace);

		Debug.Log ("hello"+fillAmount);
	//	 dist =  Vector3.Distance (finger.transform.position, lastObj.transform.position);
	//	if (dist > lastDist) {
	//		alphabet.fillAmount = (dist / 7);
	//		lastDist = dist;

	//	}


	//	Debug.Log ("dist is: "+(int )dist +" fill is "+alphabet.fillAmount);
	}
	void OnTriggerEnter2D( Collider2D other){
		Debug.Log ("hello.."+fillAmount);

		//dist =  Vector3.Distance (finger.transform.position, lastObj.transform.position);


		if (other.tag == "tracing" && fillAmount<=0.1 ) {
			Debug.Log ("this is tracing");
			trace = "tracing";
		} 
	}
	void OnTriggerExit2D(){

		trace = " ";
		Debug.Log ("hello exit");
	}
}
