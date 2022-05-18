using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour {
	public  Text  DeviceId;
	protected  string mobile_id ;
//	private const string plText; 
	public string activeSceneName;
	// Use this for initialization
	void Start () {
		
		//if(activeStr =="diyar4443968" )
		//	gameObject.SetActive (false);
		//else
		//	gameObject.SetActive (true);
		//DeviceId.text = "50b35dda54c6f05b".Substring (3, 8);
		#if UNITY_ANDROID 
		AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject>("getContentResolver");
		AndroidJavaClass clsSecure = new AndroidJavaClass("android.provider.Settings$Secure");
	    mobile_id = clsSecure.CallStatic<string>("getString", objResolver, "android_id");
		DeviceId.text = mobile_id.Substring(3,8);
		#endif
	    #if UNITY_IPHONE
		DeviceId.text =   UnityEngine.iOS.Device.vendorIdentifier;
		#endif
		//#else
		//DeviceId = "50b35dda54c6f05b";//dont forget delete this when end
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	public void ValidateCode(){
	//	plText =	PlayerPrefs.GetString ("plText");
	//	if (plText ==DeviceId.ToLower()) {
			

	//} //else {
//			myCodeField.text = null;
//			actvCode = "";
//			PlayerPrefs.SetString ("actvCode", actvCode);
//			placeholder.text = "please enter correct code";
//		}
	}
	public void sendDeviceIdMessage(){
		
		string mobile_num = "+9647504583908";
		string message =mobile_id.Substring(3,8);

		#if UNITY_ANDROID  
		string URL = string.Format("sms:{0}?body={1}",mobile_num,message);
		#endif

		#if UNITY_IOS  
		string URL = string.Format("sms:{0}?&body={1}",mobile_num,WWW.EscapeURL(message));
		#endif

		//Execute Text Message
		Application.OpenURL(URL);

	}
	public void SendBalance(string sim){
		if(sim =="korek") 
			Application.OpenURL ("tel:"+ @"*215*+9647504583908*1000"+WWW.EscapeURL("#"));

		else if (sim =="asia") 
		Application.OpenURL ("tel:"+ @"*123*1000*07725480102"+WWW.EscapeURL("#"));
		
	}

	public void BackToScene(){
		activeSceneName = PlayerPrefs.GetString ("activeSceneName");

		SceneManager.LoadScene (activeSceneName); 
	}
}

