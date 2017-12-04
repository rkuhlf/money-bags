using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalSpawner : MonoBehaviour {

    public bool right = false;
    public static float spawnRate = 10;

    public GameObject robber;

    private float timePerRobber = 1f;

    private void Start()
    {
        StartCoroutine("SpawnRobbers");
    }

    private IEnumerator SpawnRobbers()
    {
        while (this != null)
        {
            timePerRobber = ((MoneyChanger.moneyToWin - Player.money) / MoneyChanger.moneyToWin) * spawnRate;
            if (timePerRobber < 1)
            {
                timePerRobber = 1;
            }
            yield return new WaitForSeconds(timePerRobber);
            Criminal newlyInstantiated = Instantiate(robber, transform.position, Quaternion.identity).GetComponent<Criminal>();
            newlyInstantiated.right = right;
        }
    }

}
