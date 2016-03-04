using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
	//PUBLIC ATTRS
	public List<GameObject> cardsKinds;
	public int cardsCount;
	public bool isPlayer;

	//PRIVATE
	private List<GameObject> deck;
	private GameObject selectedCard;

	// Use this for initialization
	void Start () {
		Debug.Log("DECK STARTED");
		deck = new List<GameObject> ();
		for (int i = 0; i < cardsCount; i++){
			GameObject card = Instantiate (cardsKinds [Random.Range (0, cardsKinds.Count)]);
			deck.Add(card);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void SetPlayerHand(){
		List<GameObject> cards = CardsInHand ();
		for (int i = 0; i < cards.Count; i++) {
			cards [i].gameObject.transform.position = new Vector3 (i*2-5, -3, 0);
		}
	}

	void SetAiHand(){
		List<GameObject> cards = CardsInHand ();
		for (int i = 0; i < cards.Count; i++) {
			cards [i].gameObject.transform.position = new Vector3 (5, 5, -1);
			cards [i].gameObject.transform.Rotate (new Vector3 (0,90,0));

		}
	}


	List<GameObject> CardsInHand(){
		return deck.GetRange (0, 5);
	}

	void SelectCard(int i){
		selectedCard = deck[i];
		deck.Remove (selectedCard);
		Debug.Log ("Selected Card", selectedCard.gameObject);
	}


	//PUBLIC INTERFACE
	public void PSelectCard(int i){
		((Deck)gameObject.GetComponent (typeof(Deck))).SelectCard (i);
	}

	public List<GameObject> PCardsInHand(){
		return ((Deck)gameObject.GetComponent(typeof(Deck))).CardsInHand();
	}

	public void PSetPlayerHand(){
		((Deck)gameObject.GetComponent (typeof(Deck))).SetPlayerHand();
	}

	public void PSetAiHand(){
		((Deck)gameObject.GetComponent (typeof(Deck))).SetAiHand();
	}
}
