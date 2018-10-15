using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{

    Transform meuPlayer;
    public float minhaVelocidade;

    Vector2 target;

    Vector2 distancia;
    public int danoTiro;




    // Use this for initialization
    void Start()
    {

        meuPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(meuPlayer.position.x, meuPlayer.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, minhaVelocidade * Time.deltaTime);

        if ((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            Destroy(gameObject);

        }


    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //Dano que o player recebe do enemy chamando o script da vida do player
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(danoTiro);
            Destroy(gameObject);
        }


    }
}
