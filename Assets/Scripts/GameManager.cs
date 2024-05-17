using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instancja naszego Game Managera
    public static GameManager instance;
    //Lista cegie³ek
    public List<GameObject> bricks = new List<GameObject>();
    //Skrypt naszej kulki
    public ArcanoidBall ball;
    //czy gra trwa
    bool gameRun = false;

    void Awake()
    {
        //Przypisanie obiektu do instancji, stworzeie Singletona
        if(instance == null)
        {
            instance = this;
        }

        //Pobranie wszystkich mo¿liwych cegie³ek, szukamy ich po tagu Brick i robimy z nich listê
        bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));
        
    }

    void Update()
    {
        //Je¿eli gra siê nie rozpocze³a i klikniemy spacjê to uruchamiamy pi³kê.
        if (Input.GetKeyDown(KeyCode.Space) && !gameRun)
        {
            ball.RunBall();
            gameRun = true;
        }

        //Je¿eli znikn¹ wszystkie cegie³ki koñczyy grê
        if(gameRun && bricks.Count == 0)
        {
            EndGame(true);
        }

        //Je¿eli gra skoñczona, to po naciœniêciu klawisza R zresetujemy scenê
        if(!gameRun)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    //Funkcja koñcz¹ca grê
    public void EndGame(bool win)
    {
        gameRun = false;
        string txt = win ? "Wygrana!" : "Przegrana!";
        Debug.Log(txt);
        ball.StopBall();
    }
}
