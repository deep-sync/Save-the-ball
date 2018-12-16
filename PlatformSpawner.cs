using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject platformPrefab;
    Vector3 pos;
    bool gameOver;
    float size;

	// Use this for initialization
	void Start () {
        pos = platformPrefab.transform.position;
        size = platformPrefab.transform.localScale.x;
        gameOver = false;

        for (int i = 0; i < 100; i++)
        {
            SpawnPlatform();
        }
        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnPlatform()
    {
        if(!gameOver)
        {
            int rand = Random.Range(0, 4);
            if (rand < 2)
            {
                SpawnX();
            }
            if (rand > 2)
            {
                SpawnZ();
            }
        }
    }



    void SpawnX()
    {
        var lastPos = pos;
        lastPos.x += 1;
        pos = lastPos;
        Instantiate(platformPrefab, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        var lastPos = pos;
        lastPos.z += 1;
        pos = lastPos;
        Instantiate(platformPrefab, lastPos, Quaternion.identity);

    }
}
