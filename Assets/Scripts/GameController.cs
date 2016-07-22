using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

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

	}


	// Update is called once per frame
	void Update () {

	}
}
