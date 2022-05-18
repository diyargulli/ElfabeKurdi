using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCall : MonoBehaviour {

	public void Call(){
		string num="*100##";
		Application.OpenURL ("tel:"+num);
		Debug.Log (num);
	}
}
