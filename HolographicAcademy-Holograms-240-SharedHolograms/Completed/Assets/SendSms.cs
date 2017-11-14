using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Academy.HoloToolkit.Sharing;
public class SendSms : MonoBehaviour {
	
	public Text smsTextBox;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BroadcastSms() {
		CustomMessages.Instance.SendSms(new XString(smsTextBox.text));
		Debug.Log (string.Format("Broadcasting Message: {0}", smsTextBox.text));
	}

}
