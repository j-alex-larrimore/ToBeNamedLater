using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	private Text levelText;
	private GameObject canvas;
	public GameObject startScreen;
	public GameObject gameOverScreen;
	public Button gameOverButton;

	private void Awake(){
		if (Instance != null && Instance != this) {
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;

		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas");
		DontDestroyOnLoad (canvas);
		levelText = GameObject.Find ("Level Text").GetComponent<Text> ();
		gameOverScreen = GameObject.Find ("GameOver");
		gameOverScreen.SetActive (false);
	}

	public void StartGame(){
		startScreen = GameObject.Find ("StartScreen");
		startScreen.SetActive (false);
	}

	public void RestartGame(){
		Destroy (canvas);
		NewLevel (0);
	}

	private void OnLevelWasLoaded(int levelLoaded){
		if (levelLoaded == 0) {
			gameOverButton = GameObject.Find ("GameOverButton").GetComponent<Button>();
			gameOverButton.onClick.AddListener(RestartGame);
			Start ();
			StartGame ();
	
		}
	}

	public void GameOver(){
		gameOverScreen.SetActive (true);
	}

	public void NewLevel(int level){
		Application.LoadLevel (level);
		levelText.text = "Level: " + (level + 1);
	}

	// Update is called once per frame
	void Update () {

	}
}
