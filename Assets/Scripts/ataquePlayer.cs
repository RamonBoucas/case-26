using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquePlayer : MonoBehaviour {

    public int damageToGive;
    public Transform euMesmoEnemy;
    public Transform meuPlayer;
    Vector3 minhaPosicao;
    Vector3 posicaoEnemy;
    Vector3 distanciaEuEnemy;
    Vector3 direcaoPulo;
    public float distanciaPulo = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            minhaPosicao = euMesmoEnemy.position;
            posicaoEnemy = meuPlayer.position;

            distanciaEuEnemy = new Vector3(posicaoEnemy.x - minhaPosicao.x, posicaoEnemy.y - minhaPosicao.y, posicaoEnemy.z - minhaPosicao.z);
            //garante que a distancia do pulo seja sempre igual a 1
            direcaoPulo = (distanciaEuEnemy * -1).normalized * distanciaPulo;

            euMesmoEnemy.position += direcaoPulo;

            float minX = -8;
            float maxX = 9;
            float minY = -8;
            float maxY = 2.5f;

            float clampedX = Mathf.Clamp(euMesmoEnemy.position.x,minX,maxX);
            float clampedY = Mathf.Clamp(euMesmoEnemy.position.y, minY, maxY);

            euMesmoEnemy.position = new Vector3(clampedX, clampedY, euMesmoEnemy.position.z);









        }
    }


}
