using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public int[,] bricksArray1 = new int[,] {
        {2, 2, 3, 5, 6, 5, 3, 3},
        {2, 2, 3, 4, 5, 4, 3, 2},
        {1, 2, 2, 2, 2, 3, 2, 2},
        {0, 2, 2, 2, 2, 3, 2, 0},
        {0, 0, 3, 3, 3, 3, 0, 0},
        {0, 0, 0, 3, 3, 0, 0, 0},
    };

    public int[,] bricksArray2 = new int[,] {
        {3, 3, 4, 6, 5, 6, 4, 4},
        {3, 3, 4, 5, 6, 5, 4, 3},
        {2, 3, 3, 3, 3, 4, 3, 3},
        {1, 3, 3, 3, 3, 4, 3, 1},
        {0, 1, 4, 4, 4, 4, 1, 0},
        {0, 0, 1, 4, 4, 1, 0, 0},
    };

    public int[,] bricksArray3 = new int[,] {
        {1, 1, 2, 4, 5, 4, 2, 2},
        {1, 1, 2, 3, 4, 3, 2, 1},
        {0, 1, 1, 1, 1, 2, 1, 1},
        {0, 1, 1, 1, 1, 2, 1, 0},
        {0, 0, 2, 2, 2, 2, 0, 0},
        {0, 0, 0, 2, 2, 0, 0, 0},
    };

    public int[,] bricksArray4 = new int[,] {
        {2, 3, 3, 5, 6, 5, 3, 3},
        {2, 3, 3, 4, 5, 4, 3, 2},
        {1, 2, 3, 3, 3, 3, 2, 1},
        {0, 1, 2, 3, 3, 3, 2, 0},
        {0, 0, 1, 3, 3, 1, 0, 0},
        {0, 0, 0, 1, 1, 0, 0, 0},
    };

    public int[,] bricksArray5 = new int[,] {
        {2, 3, 4, 6, 6, 6, 4, 3},
        {2, 3, 4, 5, 6, 5, 4, 3},
        {1, 2, 3, 4, 4, 3, 2, 1},
        {0, 1, 2, 3, 3, 2, 1, 0},
        {0, 0, 1, 2, 2, 1, 0, 0},
        {0, 0, 0, 1, 1, 0, 0, 0},
    };

    public List<int[,]> levels;

    public GameObject brick;

    private void Awake()
    {
        levels = new List<int[,]> { bricksArray1, bricksArray2, bricksArray3, bricksArray4, bricksArray5 };
    }

    private void Start()
    {
        StartLevel(1);
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

    public void StartLevel(int number)
    {
        GameManager.instance.bricks.Clear();
        GenerateBricks(levels[number - 1]);
    }
}
