using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyChanger : MonoBehaviour {

    public static float moneyToWin = 1000000;

    public Sprite[] sprites;

    private SpriteRenderer sr;
    private float moneyInc;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        moneyInc = moneyToWin / sprites.Length;
    }

    private void Update()
    {
        for (float i = sprites.Length - 1; i >= 0; i--)
        {
            if (Player.money > i * moneyInc)
            {
                sr.sprite = sprites[(int)i];
                break;
            }
        }

        if (Player.money <= 0)
        {
            sr.sprite = null;
            Lose();
        } else if (Player.money >= moneyToWin)
        {
            Win();
        }
    }

    private void Win()
    {
        Player.money = 10000;
        SceneManager.LoadScene("Win");
    }

    private void Lose()
    {
        Player.money = 10000;
        SceneManager.LoadScene("Lose");
    }

}
