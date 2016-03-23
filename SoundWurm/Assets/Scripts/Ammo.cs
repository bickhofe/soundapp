using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public Main MainScript;
	public Speaker SpeakerScript;
	Rigidbody2D rb;
	public float power = 100;

	// Use this for initialization
	void Start () {
		MainScript = GameObject.Find ("Main").GetComponent<Main> ();
		rb = GetComponent<Rigidbody2D>();
		SpeakerScript = GameObject.Find ("speaker").GetComponent<Speaker> ();
		transform.rotation = Quaternion.Euler(new Vector3(0,0,SpeakerScript.rotAngle-90));
		rb.AddForce(transform.up * power);

		Destroy (gameObject, 5);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("cloud hit");
		if (other.gameObject.tag == "Cloud") {
			MainScript.cloudScore++;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
