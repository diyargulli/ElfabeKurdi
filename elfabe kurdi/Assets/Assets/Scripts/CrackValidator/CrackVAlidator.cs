using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackVAlidator : MonoBehaviour {
	private string mobile_id;
	protected  string DeviceId;
	protected  string currentDeviceId;
	public GameObject crackValidatorGO;
	public 
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("sceneid", 0);
		#if UNITY_ANDROID 
		AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject>("getContentResolver");
		AndroidJavaClass clsSecure = new AndroidJavaClass("android.provider.Settings$Secure");
		mobile_id = clsSecure.CallStatic<string>("getString", objResolver, "android_id");
		 currentDeviceId =mobile_id.Substring(3,8);
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString ("DeviceId")!=""  && PlayerPrefs.GetString ("DeviceId")!=null)
		 DeviceId=PlayerPrefs.GetString ("DeviceId");
	//	currentDeviceId=	"50b35dda54c6f05b9"; 
		if (DeviceId != null && DeviceId != "" && DeviceId != currentDeviceId) {
			crackValidatorGO.SetActive (true);
		} else if (DeviceId == currentDeviceId && DeviceId =="" && DeviceId != null ) {
			crackValidatorGO.SetActive (false);
		}

		
		
	}
}
