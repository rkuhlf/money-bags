using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;

    public float rate = 4;

    private float leftExtent;
    private float rightExtent;

    private void Awake()
    {
        leftExtent = transform.Find("LeftExtent").transform.position.x;
        rightExtent = transform.Find("RightExtent").transform.position.x;
    }

    private void Update()
    {
        if (Random.Range(0, 100) < rate)
        {
            float x = Random.Range(leftExtent, rightExtent);
            Instantiate(prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
