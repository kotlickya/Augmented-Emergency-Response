using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Academy.HoloToolkit.Sharing;
public class RecieveMessageScript : MonoBehaviour {

	public Text smsTextBox;
	// Use this for initialization
	void Start () {
		Debug.Log ("Init handler");
		CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.Sms] = this.OnSmsRecieved;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnSmsRecieved(NetworkInMessage msg)
	{
		Debug.Log ("Got an SMS :)");
		msg.ReadInt64();

		XString text = CustomMessages.Instance.ReadText (msg);
		Debug.Log (string.Format("Recieved Message: {0}", text));
		smsTextBox.text = text.ToString ();

	}
}
