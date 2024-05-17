using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    //Prêdkoœæ naszej paletki
    public float speed = 5f;

    void Update()
    {
        Move();
    }

    //funkcja odpowiedzialna za ruch
    void Move()
    {
        //Pobranie informacji z strza³ek prawo-lewo lub klawiszy a-d w któr¹ stronê siê poruszamy
        //GetAxisRaw zwraca tylko wartoœci -1, 0 i 1, dziêki temu prêdkoœæ zawsze bêdzie sta³a
        float x = Input.GetAxisRaw("Horizontal");

        //Przeliczamy prêdkoœæ, kierunek i ró¿nicê czasu pomiêdzy klatkami
        float speddDir = x * speed * Time.deltaTime;

        //zmieniamy pozycjê naszej paletki
        transform.position += new Vector3(speddDir, 0, 0);

    }
}
