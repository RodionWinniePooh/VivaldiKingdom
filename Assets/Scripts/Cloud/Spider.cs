using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float dirX;

    //[SerializeField]
    public float moveSpeed = 0.1f;

    public float first;
    public float second;


    Rigidbody2D rb;

    //bool facingRight = false;

    //Vector3 localScale;

    // Use this for initialization
    void Start()
    {
        //localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        //dirX = -1f;
    }

    // Update is called once per frame   
    //-2.74f
    //-2.38f
    void Update()
    {
        if (transform.position.y < first)
            dirX = 1f;
        else if (transform.position.y > second)
            dirX = -1f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, dirX * moveSpeed);
    }
}
