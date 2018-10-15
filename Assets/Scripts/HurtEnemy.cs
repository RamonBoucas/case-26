using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;
    public Transform meuEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            // Dano recebido pelo inimigo chamando o script da vida
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            //Animação de dano da espada
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            //Dano aparecendo
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;

          

        }
    }


     
}
