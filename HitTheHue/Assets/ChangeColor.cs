using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Google.Cloud.Datastore.V1;

public class ChangeColor : MonoBehaviour {

	public GameObject button;
	public GameObject apple;
	public GameObject banana;
	public GameObject watermelon;
	public GameObject orange;
	public Material mat;
	public Material plain;
	public Renderer rend;
	private DateTime start;
	private DateTime end;
	private static List<String> wrongGuesses;
	private static int wrongCount;
	private bool bChange = false;
    string projectId = "shehacksproject2018";
    //private DatastoreDb db; //= DatastoreDb.Create(projeFActId);
    // Use this for initialization
    void Start () 
	{
        //db = DatastoreDb.Create(projectId);
        start = DateTime.Now;
		wrongGuesses = new List<string> ();
		rend = apple.GetComponent<Renderer>();
		bChange = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		String color = button.name;
		if (OVRInput.Get (OVRInput.RawButton.X)) 
		{
			Application.Quit ();
		}
		Debug.Log (banana.activeSelf);
		if (apple.activeSelf) {
			if (color == "Red" && OVRInput.Get (OVRInput.RawButton.A)) {
				rend.material = mat;
				GameObject c1 = GameObject.Find ("Apple_LOD1");
				GameObject c2 = GameObject.Find ("Apple_LOD0");
				c1.GetComponent<Renderer> ().material = mat;
				c2.GetComponent<Renderer> ().material = mat;
				Debug.Log ("here1");
				//rend.materials[0].SetColor("_Color", Color.red);
				end = DateTime.Now;
				int timeDiff = (int)end.Subtract (start).TotalSeconds;
				string wrongGuess = String.Join (" ,", wrongGuesses.ToArray ());
				//Debug.Log ("red and apple");

				//do db stuff
				//Query q = 
				//GqlQuery query = "INSERT INTO USER_DATA (USER_NAME,DEVICE,RESPONSE_TIME, FRUIT_NAME, COLOR_REP, INCORRECT_CHOICES) VALUES ('JANE DOE','M','3','BANANA','RED','RED');";
				//db.RunQuery(query);
				wrongGuesses = new List<string> ();
				wrongCount = 0;
				bChange = true;
			} else if (bChange) {
				System.Threading.Thread.Sleep (2000); //sleep for 2 secs
				apple.SetActive (false);
				banana.SetActive (true);
				bChange = false;
				rend.material = plain;
				GameObject c1 = GameObject.Find ("Apple_LOD1");
				GameObject c2 = GameObject.Find ("Apple_LOD0");
				c1.GetComponent<Renderer> ().material = plain;
				c2.GetComponent<Renderer> ().material = plain;
			} else {
				wrongCount++;
				wrongGuesses.Add (button.name);
			}
		} else if (banana.activeSelf) {
			if (color == "Yellow" && OVRInput.Get (OVRInput.RawButton.A)) {
				rend.material = mat;
				GameObject c1 = GameObject.Find ("Banana_LOD1");
				GameObject c2 = GameObject.Find ("Banana_LOD0");
				c1.GetComponent<Renderer> ().material = mat;
				c2.GetComponent<Renderer> ().material = mat;
				Debug.Log ("in banana");
				//rend.materials[0].SetColor("_Color", Color.red);
				end = DateTime.Now;
				int timeDiff = (int)end.Subtract (start).TotalSeconds;
				string wrongGuess = String.Join (" ,", wrongGuesses.ToArray ());
				Debug.Log (banana.activeSelf);

				//do db stuff
				wrongGuesses = new List<string> ();
				wrongCount = 0;
				bChange = true;
			} else if (bChange) {
				System.Threading.Thread.Sleep (2000); //sleep for 2 secs
				banana.SetActive (false);
				orange.SetActive (true);
				rend.material = plain;
				GameObject c1 = GameObject.Find ("Banana_LOD1");
				GameObject c2 = GameObject.Find ("Banana_LOD0");
				c1.GetComponent<Renderer> ().material = plain;
				c2.GetComponent<Renderer> ().material = plain;

				bChange = false;
			} else {
				wrongCount++;
				wrongGuesses.Add (button.name);
			}
		} else if (orange.activeSelf) {
			if (color == "Orange" && OVRInput.Get (OVRInput.RawButton.A)) {
				rend.materials [1] = mat;
				end = DateTime.Now;
				int timeDiff = (int)end.Subtract (start).TotalSeconds;
				string wrongGuess = String.Join (" ,", wrongGuesses.ToArray ());
				Debug.Log ("orange");

				//do db stuff
				wrongGuesses = new List<string> ();
				wrongCount = 0;
				bChange = true;
			} else if (bChange) {
				System.Threading.Thread.Sleep (2000); //sleep for 2 secs
				orange.SetActive (false);
				watermelon.SetActive (true);
				rend.materials [1] = plain;
				bChange = false;
			} else {
				wrongCount++;
				wrongGuesses.Add (button.name);
			}
		} else if (watermelon.activeSelf) {
			if (color == "Green" && OVRInput.Get (OVRInput.RawButton.A)) {
				rend.material = mat;
				int numOfChildren = transform.childCount;
				GameObject c1 = GameObject.Find ("default");
				c1.GetComponent<Renderer> ().material = mat;
				end = DateTime.Now;
				int timeDiff = (int)end.Subtract (start).TotalSeconds;
				string wrongGuess = String.Join (" ,", wrongGuesses.ToArray ());
				Debug.Log ("watermelon");

				//do db stuff
				wrongGuesses = new List<string> ();
				wrongCount = 0;
				bChange = true;
			} else if (bChange) {
				System.Threading.Thread.Sleep (2000); //sleep for 2 secs
				watermelon.SetActive (false);
				apple.SetActive (true);
				rend.material = plain;
				GameObject c1 = GameObject.Find ("default");
				c1.GetComponent<Renderer> ().material = plain;
				bChange = false;
			} else {
				wrongCount++;
				wrongGuesses.Add (button.name);
			}
		}
		else 
		{
			
		}
	}
}
