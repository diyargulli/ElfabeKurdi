﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour {

	Vector3 dist;
	float posX;
	float posY;
	public int  idDragged;

	public void OnMouseDown(){
		//idDragged = int.Parse( gameObject.name.Remove(0,4));//'S' 't' 'e' 'p',);
	//	PlayerPrefs.SetInt("idDragged",idDragged);
		Debug.Log(idDragged);
		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}
	public void OnMouseDrag(){
		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.position = worldPos;
	}
	void OnTriggerEnter2D(Collider2D other){
		

		}



}
