using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

	public int gamePhase = 0;

	Vector2 touchPosition;

	public Text Text;
	public int noteScore;
	public int cloudScore;
	public int maxClouds = 10;
	public int noteAmmo;
	public int bubbleCount;
	public GameObject[] instruments;
	public string character = "worm";
	public string[] toDoMsg;

	void Start(){
		noteScore = 0;
		cloudScore = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			//Application.Quit();
			Application.LoadLevel("CloudShooter");
		}

		//touch
		if (Input.touchCount > 0) {
			touchPosition = Input.GetTouch(0).position;

			RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (touchPosition), Vector2.zero);
			
			if (hitInfo != null && hitInfo.collider != null){
				if (hitInfo.collider.tag == "Worm") character = "Worm";
				else if (hitInfo.collider.tag == "Polly") character = "Polly";
			}
		}

        //mouse
//        if (Input.GetButtonDown("Fire1")) {
//            
//            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//
//            if (hitInfo != null && hitInfo.collider != null)
//            {
//                if (hitInfo.collider.tag == "Worm") character = "Worm";
//                else if (hitInfo.collider.tag == "Polly") character = "Polly";
//                print(character);
//            }
//        }

        if (gamePhase == 0 && cloudScore >= maxClouds) {
			gamePhase = 1;
		}

		Text.text = "Character: " + character + "\n" + "Noten: " + noteScore + "\n" + "Wolken: " + cloudScore + "\n" + "Ammo: " + noteAmmo + "\n" + "Auftrag: " + toDoMsg[gamePhase];
	}
}
