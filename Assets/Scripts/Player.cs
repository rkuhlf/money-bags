using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 4f;
    public float bagMoney = 10000f;

    public static float money = 10000;

    private Rigidbody2D rb;
    private Animator anim;
    private Text moneyText;

    private float scale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scale = transform.localScale.x;
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text>();
    }

    private void Update () {
        float h = Input.GetAxis("Horizontal");
        anim.SetBool("Running", h != 0);
        rb.velocity = new Vector2(h * speed, 0);
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        } else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            print("escaped");
            SceneManager.LoadScene("Menu");
            money = 10000;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MoneyBag"))
        {
            ChangeMoney(bagMoney);
            Destroy(collision.gameObject);
        }
    }

    public void ChangeMoney(float amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

}
