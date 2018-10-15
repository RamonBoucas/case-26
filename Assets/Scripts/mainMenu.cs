using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void jogar()
    {
        Debug.Log("jogar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void jogarControles()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
 
    public void jogarNovamente()
    {
        SceneManager.LoadScene("principal 1");

    }




    public void créditos()
    {
        Debug.Log("creditos");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }


    public void sair()
    {
        Debug.Log("sair");
        Application.Quit();

    }



}
