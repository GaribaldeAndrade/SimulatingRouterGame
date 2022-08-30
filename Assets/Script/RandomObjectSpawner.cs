using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    const int X_BLOCK_COUNT = 16;
    const int Y_BLOCK_COUNT = 8;
    const int BLOCK_SIZE = 5;

    public GameObject[] myObjects;
    int[,] arrayMap = new int[X_BLOCK_COUNT, Y_BLOCK_COUNT];

    void Start()
    {
        for(int i = 0; i < X_BLOCK_COUNT; ++i)
        {
            for(int j = 0; j < Y_BLOCK_COUNT; ++j)
            {
                arrayMap[i, j] = 0;
            }
        }


        for(int i = 0; i < 10; ++i)
        {
            int x = Random.Range(-X_BLOCK_COUNT/2, X_BLOCK_COUNT/2);
            int y = Random.Range(-Y_BLOCK_COUNT/2, Y_BLOCK_COUNT/2);

            if(arrayMap[x + X_BLOCK_COUNT/2, y + Y_BLOCK_COUNT/2] == 1)
            {
                --i;
                continue;
            } else
            {
                arrayMap[x + X_BLOCK_COUNT/2, y + Y_BLOCK_COUNT/2] = 1;
            }
        }

        for (int i = 0; i < X_BLOCK_COUNT; ++i)
        {
            for (int j = 0; j < Y_BLOCK_COUNT; ++j)
            {
                if (arrayMap[i, j] == 1)
                {
                    int randomIndex = Random.Range(0, myObjects.Length - 1);
                    Vector3 randomSpawnPosition = new Vector3(i * BLOCK_SIZE - (X_BLOCK_COUNT * BLOCK_SIZE) / 2 + BLOCK_SIZE/2, 1, j * BLOCK_SIZE - (Y_BLOCK_COUNT * BLOCK_SIZE) / 2 + BLOCK_SIZE/2);
                    Instantiate(myObjects[randomIndex], randomSpawnPosition, myObjects[randomIndex].transform.rotation);
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Random.Range(-X_BLOCK_COUNT / 2, X_BLOCK_COUNT / 2);
            int y = Random.Range(-Y_BLOCK_COUNT / 2, Y_BLOCK_COUNT / 2);

            if (arrayMap[x + X_BLOCK_COUNT / 2, y + Y_BLOCK_COUNT / 2] != 1)
            {
                arrayMap[x + X_BLOCK_COUNT / 2, y + Y_BLOCK_COUNT / 2] = 1;
            } else
            {
                return;
            }

            int randomIndex = Random.Range(0, myObjects.Length - 1);
            Vector3 randomSpawnPosition = new Vector3(x * BLOCK_SIZE + BLOCK_SIZE/2, 1, y * BLOCK_SIZE + BLOCK_SIZE/2);
            Instantiate(myObjects[randomIndex], randomSpawnPosition, myObjects[randomIndex].transform.rotation);
        }
    }
}