using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraSaudePlayer : MonoBehaviour
{

    public Image barraVidaUI;
    public float vidaMaxima;
    public float vidaAtual;
 


    // Use this for initialization
    void Start()
    {
       // vidaMaxima = 100;
       // vidaAtual = phm.vidaAtual;
    }

    // Update is called once per frame
    void Update()
    {

      //  vidaMaxima = phm.vidaMaxima;
       // vidaAtual = phm.vidaAtual;

      //  float fracaoVida = (vidaAtual / vidaMaxima);
      //  barraVidaUI.rectTransform.sizeDelta = new Vector2(fracaoVida * 200, 20);
    }


    public void atualiza (float vidaMaxima , float vidaAtual)
    {

        float fracaoVida = (vidaAtual / vidaMaxima);
        barraVidaUI.rectTransform.sizeDelta = new Vector2(fracaoVida * 200, 20);

    }


}
