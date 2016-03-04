using UnityEngine;
using System.Collections;

public class Carta : MonoBehaviour {

	public int pontosAtaque;
	public int pontosDefesa;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
            Destroy(gameObject);
	}

}
