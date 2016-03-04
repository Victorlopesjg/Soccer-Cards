using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
	//PUBLIC ATTRS
	public List<GameObject> cardsKinds;
	public int cardsCount;
	public bool isPlayer;
	public List<float> playerCardsPositions;

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
			Transform cardTransform = cards [i].gameObject.transform;
			cardTransform.position = new Vector3 (playerCardsPositions[i], -3.94F, 0F);	
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
		if (deck.Count >= 5)
			return deck.GetRange (0, 5);
		else
			return deck.GetRange (0, deck.Count);
	}

	void SelectCard(int i){
		if (selectedCard)
			Destroy (selectedCard);
		selectedCard = deck[i];
		deck.Remove (selectedCard);
		if (isPlayer) {
			selectedCard.transform.position = new Vector3 (-1, -1, 0);
			SetPlayerHand ();
		} else {
			selectedCard.transform.position = new Vector3 (1, -1, 0);
			selectedCard.transform.Rotate (new Vector3 (0,-90,0));
		}
		Debug.Log ("Selected Card", selectedCard.gameObject);
	}


	//PUBLIC INTERFACE
	public Carta PSelectedCard(){
		return (Carta)((Deck)gameObject.GetComponent (typeof(Deck))).selectedCard.GetComponent(typeof(Carta));
	}

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
