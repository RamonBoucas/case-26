using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthManager1 : MonoBehaviour
{

    public int vidaMaxima;
    public int vidaAtual;
    public Image barraVidaUI;
    public Text vida;

    public static int quantidadeInimigosExistenstes = 1;
    public static int quantidadeInimigosMortos;

    public Transform euMesmoEnemy;

    // Use this for initialization
    void Start()
    {
        vidaAtual = vidaMaxima;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual <= 0)
        {
           
            // nao deixa com que a vida do inimigo seja um valor negativo
            vidaAtual = 0;
            //conta que mais um inimigo morreu
            quantidadeInimigosMortos++;
            //representa efetivamente a morte do inimigo
            Destroy(gameObject);


            // passa para o próximo nível
            if (quantidadeInimigosMortos == quantidadeInimigosExistenstes)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            //representa efetivamente a morte do inimigo
            Destroy(gameObject);
        }

        if (vidaAtual > vidaMaxima)
        {
            // nao deixa a vida atual ultrapassar a vida maxima
            vidaAtual = vidaMaxima;
        }


        atualiza(vidaMaxima, vidaAtual);
    }

    public void HurtEnemy(int damageToGive)
    {
        vidaAtual -= damageToGive;

        MovepontoAleatorio(0, 6, -4.5f, -8.5f);
    }
    public void SetMaxHealth()
    {
        vidaAtual = vidaMaxima;

    }

    public void atualiza(float vidaMaxima, float vidaAtual)
    {

        float fracaoVida = (vidaAtual / vidaMaxima);
        barraVidaUI.rectTransform.sizeDelta = new Vector2(fracaoVida * 100, 9);
        vida.text = vidaAtual.ToString();
    }





    public void regenera(int valorRegeneracao)
    {
        Debug.Log("regenerou");

        vidaAtual += valorRegeneracao;

    }


    Vector2 MovepontoAleatorio(float limiteMinX, float limiteMaxX, float limiteMinY, float limiteMaxY)
    {
       float  numeroX = Random.Range(limiteMinX, limiteMaxX);
        Debug.Log(numeroX);
        float numeroY = Random.Range(limiteMinY, limiteMaxY);
        Debug.Log(numeroY);

        Vector2 ponto = new Vector2(numeroX, numeroY);

        euMesmoEnemy.position = ponto;


        return ponto;
    }

}




