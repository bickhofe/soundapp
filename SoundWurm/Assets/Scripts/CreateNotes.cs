using UnityEngine;
using System.Collections;

public class CreateNotes : MonoBehaviour {

	public int maxNotes = 5;
	public GameObject Note;
	public GameObject[] allNotes;

	// Use this for initialization
	void Start () {
		allNotes = new GameObject[maxNotes];
		InitNotes();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitNotes(){
		for (int i = 0; i<maxNotes; i++) {
			GameObject newNote = Instantiate(Note, new Vector3(-5 + i * 2, 0, 0), Quaternion.identity) as GameObject;
			newNote.transform.parent = transform;
			allNotes[i] = newNote;
		}
	}

	public void resetNotes(){
		for (int i = 0; i<maxNotes; i++) {
			if (allNotes[i].activeSelf == false) {
				allNotes[i].SetActive(true);
				Debug.Log("note "+i+" resetted!");
				return;
			}
		}
	}
}
