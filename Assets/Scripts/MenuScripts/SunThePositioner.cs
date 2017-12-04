using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunThePositioner : MonoBehaviour {

	public GameObject PlayerModel;
	public GameObject RaceDiana;
	public GameObject BattleDiana;
	public GameObject[] Players = new GameObject[4];
	public GameObject[] Cannons = new GameObject[4];
	private int playersNumber;

	// Use this for initialization
	void Start () {

		GameController.control.Sun = this.gameObject;

		// INICIAR LA PARTIDA:
		playersNumber = GameController.control.PlayersNumber;
		for (int i = 0; i < playersNumber; i++) {
			float place = -30f + 20*i;
			Cannons [i] = Instantiate (GameController.control.PlayerCannon [i], new Vector3 (place, 21.2f, -370f), Quaternion.Euler (new Vector3(-25f,0f,0f)));
		}

		// INICIAR EL MODO DE JUEGO:
		if (GameController.control.RaceMode) {
			Instantiate (RaceDiana, new Vector3 (0, 14f, 300f),Quaternion.Euler(new Vector3(0,-90f,0)));
		}
	}



	// Update is called once per frame
	void Update () {
	}

	public void CreatePlayers(){
		for (int i = 0; i < playersNumber; i++) {
			Players [i] = Instantiate (PlayerModel);
			Players [i].GetComponent<PlayerComponents> ().PlayerType = i + 1;
			Players [i].GetComponent<PlayerComponents> ().WillPlay = true;
			// Aqui va el if (GameController.control.RaceMode){} para cuando hagamos el battle mode...
			Players [i].GetComponent<PlayerComponents> ().Cannon = Cannons [i];

			Players [i].GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [0], Vector3.zero, Quaternion.Euler(Vector3.zero));
			Players [i].GetComponent<PlayerMovement>().buildmovement = true;
			Players [i].GetComponent<PlayerMovement> ().builSellected = 0;
		}
		if (playersNumber == 3) {
			Players[3] = Instantiate (PlayerModel);
			Players[3].GetComponent<PlayerComponents> ().PlayerType = 4;
			Players [3].GetComponent<PlayerComponents> ().WillPlay = false;
		}
	}

	public void nextTurn(){
		for (int i = 0; i < playersNumber; i++) {
			
			// Aqui va el if (GameController.control.RaceMode){} para cuando hagamos el battle mode...
			Players [i].GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [0], Vector3.zero, Quaternion.Euler(Vector3.zero));
			Players [i].GetComponent<PlayerMovement>().buildmovement = true;
			Players [i].GetComponent<PlayerMovement> ().builSellected = 0;
		}
	}

}
