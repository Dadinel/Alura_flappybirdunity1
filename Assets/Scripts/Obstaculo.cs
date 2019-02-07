using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {
	[SerializeField]
	private float velocidade;
	[SerializeField]
	private float variacaoDaPosicaoY;
	private Vector3 posicaoDoAvicao;
	private bool pontuei;
	private Pontuacao pontuacao;
	// Use this for initialization
	/*void Start () {
		
	}*/

	private void Awake() {
		this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY,variacaoDaPosicaoY));
	}
 
	private void Start() {
		this.posicaoDoAvicao = GameObject.FindObjectOfType<Aviao>().transform.position;
		this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
	}

	// Update is called once per frame
	private void Update () {
		this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);

		if(!this.pontuei && this.transform.position.x < this.posicaoDoAvicao.x) {
			this.pontuei = true;
			this.pontuacao.AdicionarPontos();
		}
	}

	private void OnTriggerEnter2D(Collider2D outro) {
		this.Destruir();
	}

	public void Destruir() {
		GameObject.Destroy(this.gameObject);
	}
}
