using UnityEngine;

public class BricksScript : MonoBehaviour
{
    public int lives = 1;

    public void SetBrick(int life)
    {
        this.lives = life;
        if(lives <= 0)
        {
            Destroy(this.gameObject);
        }
        BrickColor();
    }

    private void BrickColor()
    {
        var renderer = this.gameObject.GetComponent<Renderer>();
        var colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan };
        int colorIndex = Mathf.Clamp(lives - 1, 0, colors.Length - 1);
        renderer.material.color = colors[colorIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            lives--;
            BrickColor();

            if (lives <= 0)
            {
                GameManager.instance.bricks.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
