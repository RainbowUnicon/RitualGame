/*
 * Controller for GameObjects
 * Created By: Mad Labyrinth Studios
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Controller : MonoBehaviour {
	
	//Turns candle lights on/off
	public bool candlesLightsOn = true;

	//Turns candle flame and smoke on/off
	public bool candlesParticlesOn = true;

	//Turns rising rune particles on/off
	public bool runeParticlesOn = true;

	//Turns the eye light on/off
	public bool eyeLightOn = true;

	//Turns the eye smoke on/off
	public bool eyeParticlesOn = true;

	//Turns the smoke at the base on/off
	public bool baseParticlesOn = true;

	//Turns the lights at the base on/off
	public bool baseLightsOn = true;

	//Candle lights list
	public List<GameObject> candleLights;

	//Candle particles list
	public List<GameObject> candleParticles;

	//Base lights list
	public List<GameObject> baseLights;

	//Base particles list
	public List<GameObject> baseParticles;
	
	//Rune particles gameobject
	public GameObject runeParticles;
	
	//Eye particles gameobject
	public GameObject eyeParticles;

	//Eye light gameobject
	public GameObject eyeLight;
	
	// Start is called at initialization time of the object
	void Start(){
		if (runeParticles == null)
			FindObjects (ref runeParticles,"Rune/Rune (Particle System)");
		if (eyeParticles == null)
			FindObjects (ref eyeParticles,"Eye Effects/Smoke (Particle System)");
		if (eyeLight == null)
			FindObjects (ref eyeLight,"Eye Effects/Light");
		if (candleParticles.Count < 1)
			AddChildrenToList (candleParticles,"Candles","Fire (Particle System)");
		if (candleLights.Count < 1)
			AddChildrenToList (candleLights,"Candles","Fire (Lights)");
		if (baseParticles.Count < 1)
			AddChildrenToList (baseParticles,"Shrine_Base","Smoke (Particle System)");
		if (baseLights.Count < 1)
			AddChildrenToList (baseLights,"Shrine_Base","Light");

	}
	// Awake is called when the object becomes active

	void Awake(){
		if (runeParticles == null)
			FindObjects (ref runeParticles,"Rune/Rune (Particle System)");
		if (eyeParticles == null)
			FindObjects (ref eyeParticles,"Eye Effects/Smoke (Particle System)");
		if (eyeLight == null)
			FindObjects (ref eyeLight,"Eye Effects/Light");
		if (candleParticles.Count < 1)
			AddChildrenToList (candleParticles,"Candles","Fire (Particle System)");
		if (candleLights.Count < 1)
			AddChildrenToList (candleLights,"Candles","Fire (Lights)");
		if (baseParticles.Count < 1)
			AddChildrenToList (baseParticles,"Shrine_Base","Smoke (Particle System)");
		if (baseLights.Count < 1)
			AddChildrenToList (baseLights,"Shrine_Base","Light");
	}
	
	//Update is being used for demostation purposes.
	//Recommended to use the methods below instead of an update method per Shrine for performance reasons
	void Update(){
		if (candlesLightsOn)
			TurnOn (candleLights);
		else
			TurnOff (candleLights);
		
		if (candlesParticlesOn)
			TurnOn (candleParticles);
		else
			TurnOff (candleParticles);
		
		if (runeParticlesOn)
			TurnOn (runeParticles);
		else
			TurnOff (runeParticles);

		if (eyeLightOn)
			TurnOn (eyeLight);
		else
			TurnOff (eyeLight);

		if (eyeParticlesOn)
			TurnOn (eyeParticles);
		else
			TurnOff (eyeParticles);

		if (baseParticlesOn)
			TurnOn (baseParticles);
		else
			TurnOff (baseParticles);

		if (baseLightsOn)
			TurnOn (baseLights);
		else
			TurnOff (baseLights);

	}
	
	//Activates given gameobject in the scene
	public void TurnOn(GameObject go){
		if (go != null)
			go.SetActive (true);
	}
	
	//Deactivates given gameobject in the scene
	public void TurnOff(GameObject go){
		if (go != null)
			go.SetActive (false);
	}

	//Activates given list of gameobjects in the scene
	public void TurnOn(List<GameObject> go){
		for (int i=0; i<go.Count; i++) {
			if (go[i] != null)
				go[i].SetActive (true);
		}
	}
	
	//Deactivates given list of gameobjects in the scene
	public void TurnOff(List<GameObject> go){
		for (int i=0; i<go.Count; i++) {
			if (go[i] != null)
				go[i].SetActive (false);
		}
	}

	//Searches for children called 'name' and if found sets the object to 'go'
	public void FindObjects(ref GameObject go,string name){
		Transform temp = this.gameObject.transform.FindChild (name);
		if(temp != null){
			go = temp.gameObject;
		}

	}

	//Adds child GameObjects to List within parent's directory with provided child name
	public void AddChildrenToList(List<GameObject> go,string parentName,string childName){
		Transform parent = this.gameObject.transform.FindChild(parentName);
		if (parent != null) {
			Transform[] allChildren = parent.GetComponentsInChildren<Transform> ();
			foreach (Transform child in allChildren) {
				if (child.name.Equals (childName)) {
					go.Add (child.gameObject);
				}
			}
		}
	}

	
}
