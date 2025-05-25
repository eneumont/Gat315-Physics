using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
	[SerializeField] IntVariable score;
	[SerializeField] GameObject layout;
	[SerializeField] TMP_Text playScoreTxt;
	[SerializeField] TMP_Text winScoreTxt;
	[SerializeField] Image StarOneImg;
	[SerializeField] Image StarTwoImg;
	[SerializeField] Image StarThreeImg;

	[Header("Events")]
	[SerializeField] VoidEvent gameStartEvent;
	[SerializeField] VoidEvent gameWinEvent;
	[SerializeField] VoidEvent gameLoseEvent;

	public enum State {
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_OVER,
		GAME_WON
	}
	private State state = State.TITLE;

	void OnEnable() {
		gameWinEvent.Subscribe(winGame);
		gameLoseEvent.Subscribe(loseGame);
	}

	void Update() {
		switch (state) {
			case State.TITLE:
				UIManager.Instance.SetActive("Title", true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;

			case State.START_GAME:
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				// reset values
				score.value = 0;

				if (layout) {
					Destroy(layout); 
					Instantiate(layout);
				}
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

				state = State.PLAY_GAME;

				gameStartEvent.RaiseEvent();
				break;
			case State.PLAY_GAME:
				UIManager.Instance.SetActive("Play", true);

				playScoreTxt.text = "Score " + score.value;
				break;
			case State.GAME_OVER:
				UIManager.Instance.SetActive("Lose", true);

				break;
			case State.GAME_WON:
				UIManager.Instance.SetActive("Win", true);

				winScoreTxt.text = "Score " + score.value;
				break;
			default:
				break;
		}
	}

	public void startGame() { 
		state = State.START_GAME;
	}

	public void loseGame() {
		state = State.GAME_OVER;
	}

	public void winGame() { 
		state = State.GAME_WON;

		if (score <= 50000) {
			StarOneImg.gameObject.SetActive(true);
			StarTwoImg.gameObject.SetActive(false);
			StarThreeImg.gameObject.SetActive(false);
		} else if (score <= 70000) {
			StarOneImg.gameObject.SetActive(true);
			StarTwoImg.gameObject.SetActive(true);
			StarThreeImg.gameObject.SetActive(false);
		} else {
			StarOneImg.gameObject.SetActive(true);
			StarTwoImg.gameObject.SetActive(true);
			StarThreeImg.gameObject.SetActive(true);
		}
	}
}