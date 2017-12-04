using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal : MonoBehaviour {

    public float speed = 3f;
    public float stolenAmount = 50000;
    public bool right = false;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Animator anim;

    private bool turnedAround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPosition = transform.position;

        if (right)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void Update()
    {
        if (right)
        {
            if (transform.position.x > startPosition.x)
            {
                anim.SetTrigger("FadeOut");
                StartCoroutine("Die");
            }
        } else
        {
            if (transform.position.x < startPosition.x)
            {
                anim.SetTrigger("FadeOut");
                StartCoroutine("Die");
            }
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (turnedAround)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ChangeMoney(stolenAmount / 2);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, 0);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ChangeMoney(-stolenAmount);
            turnedAround = true;
        }
    }

}
