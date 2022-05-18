using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DecryptCode : MonoBehaviour {
	public Text plInput;
	private string siphTextSmall;//="333d33";
	protected string plText="";
	private string code;
	protected string DeviceId;//="";// = "123a12";//.ToLower();
	private int key;
	private int assc;
	private char currentChar;
	private char currentKeyChar;
	public InputField activeCodetxt;
	//public Text codeTXT;
	public Text message;
	public GameObject CongratsPanel;

	// Use this for initialization
	void Start () {
		DeviceId = plInput.text.ToString ().ToLower ();

	}
	
	// Update is called once per frame
	void Update () {
	//	PlayerPrefs.SetString ("DeviceId","50b35dda54c6f05b");
	//	if (DeviceId == plText) {

	//	}
	}
	private void Decrypt(){
		
		plText = "";
		//codeTXT.text = "";
		key = 0;
		DeviceId = plInput.text.ToString ().ToLower ();
		//DeviceId ="50b35dda54c6f05b"; 
		if (DeviceId != "" && activeCodetxt.text.Length== DeviceId.Length) {
			//plText = plInput.text;
			try{
			siphTextSmall = activeCodetxt.text.ToLower ();// code for sender ccc

//			Debug.Log (DeviceId);

			for (int i = 0; i < DeviceId.Length; i++) {
				// key generator
				//	key = Convert.ToChar( plTextSmall [plTextSmall.Length-1-i]);
				currentKeyChar = DeviceId [DeviceId.Length - 1 - i];

				if (currentKeyChar>= 'a' && currentKeyChar<= 'z') {

						key = currentKeyChar;
						key = key- 97;
						key = key % 9;
				//	


				} else  if (int.Parse(currentKeyChar.ToString()) >= 0 &&
						int.Parse(currentKeyChar.ToString()) <=9) {

					key = int.Parse (DeviceId [DeviceId.Length - 1 - i].ToString ());//int.Parse (DeviceId [DeviceId.Length - 1 - i].ToString ());
					//	Debug.Log ("key"+plTextSmall[plTextSmall.Length-1-i]+ " "+key);
					//Debug.Log ("key "+currentKeyChar+ " "+key);
					//...complete
				}

				//key;

				//Debug.Log ("key "+currentKeyChar+" int of it = "+key);
				if (DeviceId[i] >= 'a' && DeviceId[i] <= 'z') {
				//	Debug.Log (siphTextSmall+"  is sopher");
					assc= siphTextSmall[i]; //99 - 97 = 2
				//	Debug.Log (siphTextSmall[i]+" = "+assc+"  is assc key is "+key +"pl is "+(assc-key+97));
					assc = assc-97-key+26;//-key; //key%26;
					assc = assc % 26;
					assc = assc + 97;
					//	assc= siphTextSmall[i] - assc;
					currentChar= Convert.ToChar(assc);
						plText += currentChar;
				
				}else if (int.Parse(DeviceId[i].ToString()) >= 0 && int.Parse(DeviceId[i].ToString()) <=9) {
						assc=  siphTextSmall[i]- 48;       /// int.Parse( siphTextSmall[i].ToString());
						assc = assc -key+10;//9+0
						assc = assc % 10;

						plText +=assc.ToString();  // ((int.Parse( siphTextSmall[i].ToString()) -key+9)%9).ToString();
						//	Debug.Log (int.Parse( siphTextSmall [i].ToString())+" - "+ key+" = "+ plText+" i is "+i);

					}else message.text= "cant send special character exception";

//				Debug.Log ("final " + plText);
			}
				
			//codeTXT.text = plText;
				if(DeviceId==plText){
			     	message.text = "successfully registered";
					PlayerPrefs.SetString ("DeviceId", DeviceId);
					PlayerPrefs.SetString("plText",plText);
					message.color = Color.green;
					CongratsPanel.SetActive(true);
				}else{
					WrongCode ();
				}

			}catch(FormatException){
				if(DeviceId!=plText){
					WrongCode ();
				}
			}catch( IndexOutOfRangeException){
				if(DeviceId!=plText){
					WrongCode ();
				}
			}
		}if(DeviceId!=plText){
			WrongCode ();
		}
	}
	public void WrongCode(){
		message.text = "wrong activation code";
		message.color = Color.red;
	}
	public void Decr(){
		Decrypt ();
	}
	public void PasteText(){
		activeCodetxt.text=	UniClipboard.GetText ();
	}

}
