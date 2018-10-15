using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIA : MonoBehaviour
{
    // define o player que deverá ser perseguido
    public Transform meuPlayer;
    public EnemyHealthManager ehm;

    //define a velocidade do inimigo
    public float minhaVelocidade = 5;

    //distancia minima é o mais perto que o inimigo quer chegar do player
    public float distanciaMinima = 2;

    // distancia maxima é a distancia a partir da qual o inimigo resolve parar de perseguir o player
    public float distanciaMaxima = 10;

    public GameObject tiroPrefab;

    Animator anim;


    public float timeParaRegenerar;
    public float timeDecorrido;
    public int valorRegeneracao;
    public int damageToGive = 5;

    Collider[] objetos;
    Collider player;
    public Transform euMesmo;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        timeDecorrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // calcula a distancia entre o inimigo e o player
        float distancia = Vector2.Distance(transform.position, meuPlayer.position);

        //1 estado combate melee
        if (distancia < distanciaMinima)
        {
            timeDecorrido = 0;

          




        }

        //2 estado o de movimentação
        if ((distancia > distanciaMinima) && (distancia < distanciaMaxima))
        {
            // move o inimigo na direção do player
            timeDecorrido = 0;
            transform.position = Vector2.MoveTowards(transform.position, meuPlayer.position, minhaVelocidade * Time.deltaTime);
        }

        // 3 estado o de combate ranged



        if (distancia > distanciaMaxima)
        {

            if (timeDecorrido > timeParaRegenerar)
            {
                ehm.regenera(valorRegeneracao);
                timeDecorrido = 0;
               
            }
            else
            {
                timeDecorrido += Time.deltaTime;
            }

        }

       
    }

    public void atacaPlayer(Collider player)
    {
        player.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);

        Debug.Log("atacou");

    }

   

}


