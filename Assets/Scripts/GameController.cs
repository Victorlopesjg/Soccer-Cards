using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject deck;
	public Text playerScore;
	public Text aiScore;
	public Text turn;

	private int playerPoints = 0;
	private int aiPoints = 0;

	private GameObject player;
	private GameObject ai;

	private Deck playerDeck;
	private Deck aiDeck;

	private int isAtackTurn;
	// Use this for initialization

	void Start () {
		StartCoroutine (startDecksCoroutine());
		isAtackTurn = 1;
	}

	IEnumerator startDecksCoroutine(){
		StartDeckObjects ();
		yield return new WaitForSeconds(1);
		SetDecks ();
	}

	void StartDeckObjects(){
		player = Instantiate (deck);
		ai = Instantiate (deck);
	}

	void SetDecks(){
		playerDeck = (Deck) player.GetComponent (typeof(Deck));
		aiDeck = (Deck) ai.GetComponent (typeof(Deck));
		playerDeck.isPlayer = true;
		playerDeck.PSetPlayerHand ();
		aiDeck.PSetAiHand ();
	}

	void SelectCard(int i){
		playerDeck.PSelectCard (i);
		aiDeck.PSelectCard(Random.Range(0, aiDeck.PCardsInHand ().Count));
		Carta playerCard = playerDeck.PSelectedCard ();
		Carta aiCard = aiDeck.PSelectedCard ();
		if (isAtackTurn == 1) {
			if (playerCard.pontosAtaque > aiCard.pontosDefesa)
				playerPoints++;
			else
				aiPoints++;
		} else {
			if (playerCard.pontosDefesa > aiCard.pontosAtaque)
				playerPoints++;
			else
				aiPoints++;
		}
		Debug.Log (aiPoints);
		isAtackTurn = isAtackTurn * -1;

		if (playerDeck.PCardsInHand ().Count == 0)
			EndGame ();

	}

	void EndGame(){
		if (playerPoints > aiPoints) {
			Application.LoadLevel ("Ganhou");
		}else{
			Application.LoadLevel ("Perdeu");
		}
	}

    GameObject GetClickedGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Debug.Log("Hit " + hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        else {
            Debug.Log("No hit");
            return null;
        }
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel ("Menu");
		}

		GameObject clickedCard = null;
		if (Input.GetMouseButtonDown (0)) {
            clickedCard = GetClickedGameObject();
            if (clickedCard) {
                float clickedCardX = clickedCard.transform.position.x;
                for (int i = 0; i < playerDeck.PCardsInHand().Count; i++)
                    if (clickedCardX == playerDeck.playerCardsPositions[i])
                        SelectCard(i);
            }
        }
		playerScore.text = playerPoints.ToString();
		aiScore.text = aiPoints.ToString();
		if (isAtackTurn == 1)
			turn.text = "Atack";
		else {
			turn.text = "Defend";
		}
	}


}
