using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour {
	[SerializeField]
	private float velocidade;
	private Vector3 posicaoInicial;
	private float tamanhoRealDaImagem;
	// Use this for initialization
	/*void Start () {
		
	}*/
	
	private void Awake() {
		this.posicaoInicial = this.transform.position;
		float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
		float scala = this.transform.localScale.x;
		this.tamanhoRealDaImagem = tamanhoDaImagem * scala;
	}

	// Update is called once per frame
	void Update () {
		float deslocamento = Mathf.Repeat(this.velocidade * Time.time, this.tamanhoRealDaImagem);

		this.transform.position = this.posicaoInicial + (Vector3.left * deslocamento);
	}
}