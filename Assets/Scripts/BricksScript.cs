using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    //Zmienna prywatna, któr¹ mo¿na zmieniaæ w inspektorze
    //Iloœæ ¿ycia naszej cegie³ki
    
    public int life = 1;

    //Za ka¿dym razem jak ona siê zetknie z czymœ
    private void OnCollisionEnter(Collision collision)
    {
        //Je¿eli ma to tag Ball
        if(collision.gameObject.tag == "Ball")
        {
            //usuawamy jedno ¿ycie
            life--;
            //Je¿eli ¿ycia s¹ równe lub mniejsze od 0
            if(life <= 0)
            {
                GameManager.instance.bricks.Remove(this.gameObject);
                Destroy(gameObject); //Zniszcz obiekt
            }
        }
    }
}
