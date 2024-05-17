using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        float speedDir = x * speed * Time.deltaTime;

        transform.position += new Vector3(speedDir, 0, 0);
    }
}
