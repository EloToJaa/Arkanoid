using UnityEngine;

public class ArcanoidBall : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        RunBall();
    }

    public void RunBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(x * speed, speed, 0f);
    }

    public void StopBall()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Lose")
        {
            Debug.Log("You lose!");
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
