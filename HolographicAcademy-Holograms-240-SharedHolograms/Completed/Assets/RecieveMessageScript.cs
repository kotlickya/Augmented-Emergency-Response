using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Academy.HoloToolkit.Sharing;
public class RecieveMessageScript : MonoBehaviour {

	public Text smsTextBox;
	public Image smsMessageBox;


	private float finalLocation = -3.0f;
	private float startLocation = 45f;
	public const float moveTime = 1.5f, closeIn = 3.0f;
	private float currentLocation;
	private float startTime, currT, deltaTime;

	private bool opening = false, doneOpening = false, closing = false;
	// Use this for initialization
	void Start () {
		Debug.Log ("Init handler");
		CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.Sms] = this.OnSmsRecieved;
		startLocation = smsMessageBox.rectTransform.localPosition.y + 45;
		finalLocation = smsMessageBox.rectTransform.localPosition.y - 3;
		smsMessageBox.rectTransform.localPosition = NewPos(startLocation);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab) == true) {
			opening = true;
			if (opening) {
				OpenMessage ();
				Invoke ("CloseMessage", closeIn);
			}
		}
		if (opening) {
			smsMessageBox.rectTransform.localPosition = NewPos(Mathf.Lerp (smsMessageBox.rectTransform.localPosition.y , finalLocation, Mathf.Min((Time.time - startTime)/moveTime, 1f)));
		}
		if (closing) {
			smsMessageBox.rectTransform.localPosition = NewPos(Mathf.Lerp(smsMessageBox.rectTransform.localPosition.y , startLocation, Mathf.Min((Time.time - startTime)/moveTime, 1f)));
		}
	}

	void OpenMessage() {
		startTime = Time.time;
		opening = true;
		closing = false;
		doneOpening = smsMessageBox.rectTransform.localPosition.y == finalLocation;
	}
	void CloseMessage() {
		startTime = Time.time;
		opening = false;
		closing = true;
	}

	Vector3 NewPos(float posY){
		Vector3 retVector = new Vector3(smsMessageBox.rectTransform.localPosition.x, posY ,smsMessageBox.rectTransform.localPosition.z);
		return retVector;
	}
	void OnSmsRecieved(NetworkInMessage msg)
	{
		Debug.Log ("Got an SMS :)");
		msg.ReadInt64();

		XString text = CustomMessages.Instance.ReadText (msg);
		Debug.Log (string.Format("Recieved Message: {0}", text));
		smsTextBox.text = text.ToString ();
		OpenMessage ();
		Invoke("CloseMessage", closeIn);
	}
}
