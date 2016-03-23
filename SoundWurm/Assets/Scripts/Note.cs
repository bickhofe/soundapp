using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public Main MainScript;
	float offset;
	int id;


	// Use this for initialization
	void Start () {
        offset = Random.Range(1f, 3f);
        MainScript = GameObject.Find("Main").GetComponent<Main> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//hover
		if (MainScript.gamePhase == 0) transform.position = new Vector3 (transform.position.x, Mathf.PingPong (Time.time, offset), transform.position.z);
		else if (MainScript.gamePhase == 1) gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("hit");
		if (other.gameObject.tag == "Worm") {
			MainScript.noteScore++;
			MainScript.noteAmmo++;
			gameObject.SetActive(false);
		}
	}
}
