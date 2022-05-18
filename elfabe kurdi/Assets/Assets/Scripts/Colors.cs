using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour {
	
	public Material[] mtrl;
	public  Material currMaterial;
     public int materialid=0;

	// Use this for initialization
	void Start () {
		currMaterial = mtrl [materialid];	
	}
	
	// Update is called once per frame
	void Update () {
		currMaterial = mtrl [materialid];
	}
	public void SetColor(int ID)
	{
		materialid = ID;
	}

}
