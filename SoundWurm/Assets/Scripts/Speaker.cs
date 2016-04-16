using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour {
	
	public Main MainScript;
	public CreateNotes NotesScript;
	
	public GameObject AmmoObj;
	
	public int ammo;
	public bool canShoot = false;
	public bool canAim = false;
	public float rotAngle;
	bool isTouching = false;
	Vector2 touchPosition;
	//Vector3 startMousePos;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// mouse control
//		if (MainScript.character == "Polly") {
//			if (Input.GetMouseButton(0)){
//				canAim = true;
//				isTouching = true;
//			}
//
//			if (Input.GetMouseButtonUp(0) && isTouching) {
//				canAim = false;
//				MainScript.character = "";
//
//				//fire
//				if (MainScript.noteAmmo > 0){
//					MainScript.noteAmmo--;
//					NotesScript.resetNotes();
//					GameObject newAmmo = Instantiate(AmmoObj, transform.position, Quaternion.identity) as GameObject;
//				} else {
//					Debug.Log("No ammo!");
//				}
//			}
//		}
		
		// touch control
		if (MainScript.character == "Polly") {
			if (Input.touchCount > 0){
				canAim = true;
				isTouching = true;
			}
			
			if (Input.touchCount == 0 && isTouching) {
				canAim = false;
				MainScript.character = "";
				
				//fire
				if (MainScript.noteAmmo > 0){
					MainScript.noteAmmo--;
					NotesScript.resetNotes();
					GameObject newAmmo = Instantiate(AmmoObj, transform.position, Quaternion.identity) as GameObject;
				} else {
					Debug.Log("No ammo!");
				}
			}
		}
		
		if (canAim){
			touchPosition = Input.GetTouch(0).position;
			//touchPosition = Input.mousePosition;
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touchPosition.x, touchPosition.y, 10));
			currentPosition = currentPosition - transform.position;
			rotAngle = Mathf.Atan2(currentPosition.y, currentPosition.x) * Mathf.Rad2Deg;

			if (rotAngle < 90) rotAngle = 90;
			else if (rotAngle > 159) rotAngle = 159;

			int objectAngle = 135; // Default Angle of an Object
			transform.rotation = Quaternion.AngleAxis(rotAngle - objectAngle, Vector3.forward);
		}
	}
}
