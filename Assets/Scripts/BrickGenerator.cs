using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public int[,] bricksArray = new int[,] {
        {2,2,3,5,6,5,3,3, },
        {2,2,3,4,5,4,3,2, },
        {1,2,2,2,2,3,2,2, },
        {0,2,2,2,2,3,2,0, },
        {0,0,3,3,3,3,0,0, },
        {0,0,0,3,3,0,0,0, },
    };

    public GameObject brick;

    private void Start()
    {
        GenerateBricks(bricksArray);
    }

    public void GenerateBricks(int[,] array)
    {
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                var currentBrick = array[i, j];
                if (currentBrick == 0) continue;

                var position = new Vector3((-(array.GetLength(1) / 2) + (j * 1)), (4 - i * 0.3f), 0);

                GameObject b = Instantiate(brick, position, Quaternion.identity);
                b.transform.parent = gameObject.transform;
                b.GetComponent<BricksScript>().SetBrick(currentBrick);
            }
        }
        GameManager.instance.bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));
    }
}
