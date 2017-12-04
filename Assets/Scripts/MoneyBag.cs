using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour {

    public float speed = 3f;

    private Rigidbody2D rb;
    private float deathPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        deathPoint = GameObject.FindGameObjectWithTag("DeathPoint").transform.position.y;
    }

    void Start () {
        rb.velocity = new Vector2(0, -speed);
	}

    private void Update()
    {
        if (transform.position.y < deathPoint)
        {
            Destroy(gameObject);
        }
    }

}
