﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	
	Vector3 dist;
//	float posX;
//	float posY;

	void Update(){
		
			dist = Camera.main.WorldToScreenPoint (transform.position);
//			posX = Input.mousePosition.x - dist.x;
//		    posY = Input.mousePosition.y - dist.y;
			//_move = true;

			Vector3 curPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y , dist.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;

	
		
	
	
	}
	//void OnMouseDown(){
	//	dist = Camera.main.WorldToScreenPoint (transform.position);
	//  posX = Input.mousePosition.x - dist.x;
	//	posX = Input.mousePosition.y - dist.y;


	//}
//	void OnMouseDrag(){
///		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY,dist.z);
//		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
//		transform.position = worldPos;
//	}
}
