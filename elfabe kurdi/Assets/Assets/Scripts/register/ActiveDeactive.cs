using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeactive : MonoBehaviour {
	public GameObject actvDeActObj;
	public bool isToActive;
	public void ActDeact(){
		actvDeActObj.SetActive (isToActive);
	}
}
