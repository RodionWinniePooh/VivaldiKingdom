using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    float dirX;

    float moveSpeed = 3f;
    public float firstPosition, secondPosition;

    public static bool isAttacking = false;
    public static Animator anim;
    public static bool facingRight { get; private set; }
    private GameObject _hero;
    private GameObject _goblin;
    private bool _localscaleHero;
    private bool _localscaleGoblin;
    Rigidbody2D rb;
    Vector3 localScale;

    int OntriggerInt;
    // Start is called before the first frame update
    private void Awake()
    {
        _goblin = gameObject;
        _localscaleHero = false;
        _localscaleGoblin = false;

    }
    void Start()
    {
        OntriggerInt = 0;

        facingRight = false;
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        anim = GetComponent<Animator>();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        OntriggerInt = 0;
        isAttacking = false;       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            OntriggerInt = 1;
            isAttacking = true;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") && isAttacking)
        {
            if (Hero.healthPoints == 0)
            {
                isAttacking = false;
            }
            
            Hero.healthPoints -= 1;

        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Update()
    {
        if ((transform.position.x < firstPosition) || ((!facingRight) && (OntriggerInt == 1) && (!Hero.facingRight)) )
        {
            dirX = 1f;
        }


        //((OntriggerInt == 1) && (Hero.facingRight == true)) || 
        if ((transform.position.x > secondPosition) || ((Hero.facingRight) && (facingRight) && (OntriggerInt == 1)))
        {
            dirX = -1f;
        }
        //else
        //    if(Hero.facingRight && facingRight && OntriggerInt == 1)
        //{
        //    facingRight = false;
        //    localScale.x *= -1;
        //    dirX = -1f;
        //}



        if (isAttacking)
        {
            
            anim.SetBool("isAttacking", true);
        }
        else
            if (!isAttacking)
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
            rb.velocity = Vector2.zero;
    }
}
