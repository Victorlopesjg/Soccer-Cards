using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject deck;

	private GameObject player;
	private GameObject ai;

	private Deck playerDeck;
	private Deck aiDeck;
	// Use this for initialization
	void Start () {
		StartCoroutine (startDecksCoroutine());
	}

	IEnumerator startDecksCoroutine(){
		StartDeckObjects ();
		yield return new WaitForSeconds(1);
		SetDecks ();
		SelectCard (0);
	}

	void StartDeckObjects(){
		player = Instantiate (deck);
		ai = Instantiate (deck);
	}

	void SetDecks(){
		playerDeck = (Deck) player.GetComponent (typeof(Deck));
		aiDeck = (Deck) ai.GetComponent (typeof(Deck));
		playerDeck.PSetPlayerHand ();
		aiDeck.PSetAiHand ();
	}

	void SelectCard(int i){
		playerDeck.PSelectCard (i);
	}

	// Update is called once per frame
	void Update () {
	}


}
