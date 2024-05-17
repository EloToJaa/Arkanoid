using UnityEngine;

public class BricksScript : MonoBehaviour
{
    public int life = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            life--;

            if (life <= 0)
            {
                GameManager.instance.bricks.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
