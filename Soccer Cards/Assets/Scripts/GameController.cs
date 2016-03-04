using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject deck;

	private GameObject playerDeck;
	private GameObject aiDeck;
	// Use this for initialization
	void Start () {
		StartCoroutine (startDecksCoroutine());
	}

	IEnumerator startDecksCoroutine(){
		StartDecks ();
		yield return new WaitForSeconds(1);
		LogDecks ();
	}

	void StartDecks(){
		playerDeck = Instantiate (deck);
	}

	void LogDecks(){
		Deck playerDeckScript = (Deck) playerDeck.GetComponent (typeof(Deck));
		Debug.Log (playerDeckScript.CardsInHand()[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
