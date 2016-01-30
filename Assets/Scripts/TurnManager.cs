using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	public int nPlayers;
	public int nActionsPerTurn;
	public bool gameIsRunning;

	private int actions;
	private int currentPlayer;

	// Use this for initialization
	void Start () {
		gameIsRunning = true;
		actions = nActionsPerTurn;
		currentPlayer = 0;
		/*while(gameIsRunning) {
			if(actions > 0) {
				print("Player " + (currentPlayer+1) + ", action " + (nActionsPerTurn-actions));
			} else {
				currentPlayer = (currentPlayer+1) % nPlayers;
				actions = nActionsPerTurn;
			}
		}*/
	}
	
	void OnGUI() {
		Event e = Event.current;
		if(e.isKey) {
			if(e.keyCode == KeyCode.A) {
				print("Player " + (currentPlayer+1) + ", Action A");
				actions--;
			} else if(e.keyCode == KeyCode.B) {
				print("Player " + (currentPlayer+1) + ", Action B");
				actions--;
			}
		}
	}

	void takeTurn() {
		int actions = nActionsPerTurn;
		while(actions > 0) {
			action();
			actions--;
		}
	}

	void action() {
		print("ACTION");
	}
}
