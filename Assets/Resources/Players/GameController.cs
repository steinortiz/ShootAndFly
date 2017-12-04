using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int PlayersNumber = 2;
	public int SceneToPlay=0;
	public bool RaceMode;
	public GameObject[] PlayerBall = new GameObject[4];
	public GameObject[] PlayerCannon = new GameObject[4];
	public GameObject[] PlayerExplotion = new GameObject[4];
	public GameObject[] PlayerTile = new GameObject[4];

	public GameObject[] BallElements;
	public GameObject[] CannonElements;
	public GameObject[] TileElements;
	public GameObject[] ExpElements;

	public int[] playersBallSelected = new int[4];
	public int[] playersCannonSelected = new int[4];
	public int[] playersTileSelected = new int[4];
	public int[] playersExplotionSelected = new int[4];

	public Texture[] BallsPrev;
	public Texture[] CannonPrev;
	public Texture[] TilePrev; 
	public Texture[] ExplotionPrev;

	public GameObject[] ElementsBuild;

	public float Meta = 600;
	public float[] PlayerPoints = new float[4];
	public float[] PlayerPosition = new float[4];


	// Scene Propieties

	public GameObject Sun;
	public GameObject TurnManager;
	public int Positions;
	public float[] puntos = new float[4];

	// Turn Propieties

	public bool turn;
	public int ReadyCollition;
	public int playersReady;

	// Battle Propieties



	public static GameController control;

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}

		PlayerPoints[0]= 0;
		PlayerPoints[1]= 0;
		PlayerPoints[2]= 0;
		PlayerPoints[3]= 0;
		SetPositions ();

	}

	void Update(){
		if (playersReady == PlayersNumber) {
			playersReady = 0;
			TurnManager.GetComponent<TurnController> ().camarita.GetComponent<Camera> ().enabled = false;
		}

		if (ReadyCollition == PlayersNumber) {
			ReadyCollition = 0;
			SetPositions ();
			if (Positions == PlayersNumber) {
				Positions = 0;
				TurnManager.GetComponent<TurnController> ().Nadie.GetComponent<Text> ().text = "Muy facil, Nadie Gana Puntos";
			} else {
				Positions = 0;
				TurnManager.GetComponent<TurnController> ().Nadie.GetComponent<Text> ().text = "";
				for (int i = 0; i < PlayersNumber; i++) {
					PlayerPoints [i] = PlayerPoints [i] + puntos [i];
				}
			}

			for (int i = 0; i < PlayersNumber; i++){
				Sun.GetComponent<SunThePositioner> ().Players [i].GetComponent<PlayerMovement> ().CannonMovement = false;
				Sun.GetComponent<SunThePositioner> ().Players [i].GetComponent<PlayerMovement> ().flyMovement = false;
				TurnManager.GetComponent<TurnController> ().camarita.GetComponent<Camera> ().enabled = true;
				TurnManager.GetComponent<TurnController> ().Canvasito.GetComponent<Canvas> ().enabled = true;
				TurnManager.GetComponent<TurnController> ().pointstext [i].GetComponent<Text> ().text = PlayerPoints [i].ToString ();
				if (PlayerPoints [i] >= Meta) {
					EndGame (i);
				}
			}
		}

	}


	//Settings Methods
	public void SetPlayersInGame(int value){
		PlayersNumber = value + 2;
	}

	public void SetRaceMode (){
		RaceMode = true;
	}
	public void SetBattleMode (){
		RaceMode = false;
	}

	public void LoadGameLevel(){
		for (int player = 0; player < 4; player++) {
			PlayerBall [player] = BallElements [playersBallSelected [player]];
			PlayerCannon [player] = CannonElements [playersCannonSelected [player]];
			PlayerTile [player] = TileElements [playersTileSelected [player]];
			PlayerExplotion [player] = ExpElements [playersExplotionSelected [player]];
		}

		if(SceneToPlay==0){
			SceneManager.LoadScene("FieldBattle");
		}else if(SceneToPlay==1){
			SceneManager.LoadScene("SnowDay");
		}else if(SceneToPlay==2){
			SceneManager.LoadScene("Volcano");
		}
	}

	public void LoadMenu(){
		SceneManager.LoadScene("TitleScreen");
	}

	// Turn Methods
	public void SetPositions(){
		PlayerPosition[0]= 0;
		PlayerPosition[1]= 0;
		PlayerPosition[2]= 0;
		PlayerPosition[3]= 0;
	}

	public void EndGame(int player){
		player += 1;
		TurnManager.GetComponent<TurnController> ().finaltext.GetComponent<Text> ().text = player.ToString ();
		TurnManager.GetComponent<TurnController> ().Canvasito.GetComponent<Canvas> ().enabled = false;
		TurnManager.GetComponent<TurnController> ().Final.GetComponent<Canvas> ().enabled = true;
	}

	public void Salir(){
		Application.Quit ();
	}
}
