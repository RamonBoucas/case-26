using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIA3 : MonoBehaviour
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
    public float timeDecorridoTiro;
    public float timeDecorridoRegeneracao;
    public int valorRegeneracao;

    public int timeParaTiro;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        timeDecorridoTiro = 0;
        timeDecorridoRegeneracao = 0;
    }

    // Update is called once per frame
    void Update()
    {

       


        // calcula a distancia entre o inimigo e o player
        float distancia = Vector2.Distance(transform.position, meuPlayer.position);

        //1 estado combate melee
        if (distancia < distanciaMinima)
        {

            timeDecorridoTiro = 0;
            timeDecorridoRegeneracao = 0;

            

        }

        //2 estado o de movimentação
        if ((distancia > distanciaMinima) && (distancia < distanciaMaxima))
        {
            // move o inimigo na direção do player

           
            timeDecorridoRegeneracao = 0;
            transform.position = Vector2.MoveTowards(transform.position, meuPlayer.position, minhaVelocidade * Time.deltaTime);


            if (timeDecorridoTiro >= timeParaTiro)
            {
                atirar();
                timeDecorridoTiro = 0;

            }
            else
            {
                timeDecorridoTiro += Time.deltaTime;
            }







        }

        // 3 estado o de combate ranged



        if (distancia > distanciaMaxima)
        {

            if (timeDecorridoRegeneracao >= timeParaRegenerar)
            {
                ehm.regenera(valorRegeneracao);

                timeDecorridoRegeneracao = 0;
                
            }
            else
            {
                timeDecorridoRegeneracao += Time.deltaTime;
            }

            if (timeDecorridoTiro >= timeParaTiro)
            {
                atirar();

                timeDecorridoTiro = 0;

            }
            else
            {
                timeDecorridoTiro += Time.deltaTime;
            }

        }



    }


    void atirar()
    {
        timeDecorridoTiro += Time.deltaTime;
        if (timeDecorridoTiro >= timeParaTiro)
        {
            timeDecorridoTiro = 0;
            Instantiate(tiroPrefab, transform.position, Quaternion.identity);
        }
    }
 


}
