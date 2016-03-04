using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
	//PUBLIC ATTRS
	public List<GameObject> cardsKinds;
	public int cardsCount;

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

	public void SelectCard(int index){
		selectedCard = deck [index];
		deck.Remove (selectedCard);
	}

	public List<GameObject> CardsInHand(){
		List<GameObject> cardsInHand = new List<GameObject> ();
		if (gameObject) cardsInHand.AddRange( ((Deck)gameObject.GetComponent(typeof(Deck))).deck.GetRange(0, 5) );
		return cardsInHand;
	}
}
