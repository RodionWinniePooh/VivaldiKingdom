using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    int IsButtonhit = 0;

    //public AudioClip[] impact;
    
    Rigidbody2D rb;

    public Animator anim;
    public static float dirX, moveSpeed = 5f;
    public static int healthPoints;
    public static int scoreCoinsLevel;
    bool isHurting, isDead;
    public static bool facingRight = false;

    Vector3 localScale;
    Text coinText;
    public GameObject dagger; //Меч выпавший из босса
    public GameObject daggerImg; //Меч на Канвасе
    public static int daggerInt;
    int PlatformInt;

    public GameObject heath1, heath2, heath3, health4, health5;

    public GameObject[] CanvasNarrator;
    public GameObject[] Narrator;

    //Звук в игре
    public AudioSource[] audioSource;
    //public AudioClip[] MusicClip;
    //public AudioClip MusicClip;


    bool isMoving = false;
    int isHealthSold, isHealthSold2;
    // Use this for initialization
    void Start()
    {
        facingRight = true;
        Time.timeScale = 1;
        scoreCoinsLevel = 0;
        healthPoints = 3;
        heath1.gameObject.SetActive(true);
        heath2.gameObject.SetActive(true);
        heath3.gameObject.SetActive(true);

        isHealthSold = PlayerPrefs.GetInt("isHealthSold");
        isHealthSold2 = PlayerPrefs.GetInt("isHealthSold2");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;

        daggerInt = 0;

        if (LevelControlScript.sceneIndex == 6)
        {
            Narrator[1].SetActive(false);
        }

        if (isHealthSold == 1)
        {
            health4.SetActive(true);
            healthPoints = 4;
        }



        if (isHealthSold2 == 1)
        {
            health5.SetActive(true);
            healthPoints = 5;
        }
    }

    void Update()
    {

        if (healthPoints > 5)
        {
            healthPoints = 5;
        }


        switch (healthPoints)
        {
            case 5:
                heath1.gameObject.SetActive(true);
                heath2.gameObject.SetActive(true);
                heath3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                break;
            case 4:
                heath1.gameObject.SetActive(true);
                heath2.gameObject.SetActive(true);
                heath3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(false);
                break;
            case 3:
                heath1.gameObject.SetActive(true);
                heath2.gameObject.SetActive(true);
                heath3.gameObject.SetActive(true);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            case 2:
                heath1.gameObject.SetActive(true);
                heath2.gameObject.SetActive(true);
                heath3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            case 1:
                heath1.gameObject.SetActive(true);
                heath2.gameObject.SetActive(false);
                heath3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            case 0:
                heath1.gameObject.SetActive(false);
                heath2.gameObject.SetActive(false);
                heath3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                if (healthPoints == 0)
                {
                    dirX = 0;
                    //Goblin.anim.SetBool("isAttacking", false);
                    Goblin.isAttacking = false;
                    anim.SetTrigger("isDead");
                    LevelControlScript.instance.youLose();
                }
                break;
        }



        if (CrossPlatformInputManager.GetButtonDown("Jump") && !isDead && PlatformInt == 1 || ( rb.velocity.y == 0 && CrossPlatformInputManager.GetButtonDown("Jump")))
        {
            rb.AddForce(Vector2.up * 700f);
            audioSource[1].Play();
        }

        if (rb.velocity.x != 0 && dirX != 0 && rb.velocity.y == 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (audioSource[5] != null)
            {
                if (!audioSource[5].isPlaying && LevelControlScript.sceneIndex == 6)
                    audioSource[5].Play();
            }
            if (audioSource[0] != null)
            {
                if (!audioSource[0].isPlaying && LevelControlScript.sceneIndex != 6)
                    audioSource[0].Play();
            }
        }
        else
        {
            if (audioSource[5] != null)
            {
                audioSource[5].Stop();
            }
            if (audioSource[0] != null)
            {
                audioSource[0].Stop();
            }
        }

        SetAnimationState();

        if (!isDead)
        {
            dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;  //Для телефона
        }
    }
        
    void FixedUpdate()
    {
        if (!isHurting)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }
    public void ReturnAnamation()
    {
        anim.SetBool("isSlashing", false);
    }

    void SetAnimationState()
    {

        if (dirX == 0)
        {
            anim.SetBool("isWalking", false);

            //anim.SetBool ("isRunning", false);
        }

        if (rb.velocity.y == 0 || PlatformInt==1)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
        {
            anim.SetBool("isWalking", true);

        }


        //if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
        //	anim.SetBool ("isRunning", true);
        //else
        //	anim.SetBool ("isRunning", false);

        //if (Input.GetKey (KeyCode.DownArrow) && Mathf.Abs(dirX) == 10)
        //	anim.SetBool ("isSliding", true);
        //else
        //	anim.SetBool ("isSliding", false);
        if (rb.velocity.y > 0 && PlatformInt == 0)
        {
            anim.SetBool("isJumping", true);
            //anim.SetBool("isFalling", true);
        }


        if (rb.velocity.y < 0 && PlatformInt == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }


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

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlatformInt = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            PlatformInt = 1;
        }

        if (collision.gameObject.CompareTag("Goblin") && ButtonHit.Kicking == true)
        {
            audioSource[4].Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Boss") && ButtonHit.Kicking == true)
        {

            HealthBarScript.health -= 10f;

            if (HealthBarScript.health == 0)
            {
                Destroy(collision.gameObject);
                dagger.SetActive(true);
            }
            audioSource[4].Play();
        }

        if (collision.gameObject.CompareTag("Dagger"))
        {
            Destroy(collision.gameObject);
            daggerImg.SetActive(true);
            audioSource[6].Play();
            daggerInt = 1;
            Narrator[0].SetActive(false);
            Narrator[1].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Narrator"))
            CanvasNarrator[0].SetActive(false);

        if (collision.CompareTag("NarratorSecond"))
            CanvasNarrator[1].SetActive(false);

        if (collision.CompareTag("Narrator3"))
            CanvasNarrator[2].SetActive(false);

        if (collision.CompareTag("Narrator4"))
            CanvasNarrator[3].SetActive(false);

        if (collision.CompareTag("Narrator5"))
            CanvasNarrator[4].SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            PlayerPrefs.Save();
            audioSource[2].Play();
            Destroy(col.gameObject);
            scoreCoinsLevel += 1;
        }

        if (col.CompareTag("BoxColiderLoseDownLevel"))
        {
            healthPoints -= healthPoints;
        }

        if (col.CompareTag("Narrator"))
            CanvasNarrator[0].SetActive(true);

        if (col.CompareTag("NarratorSecond"))
            CanvasNarrator[1].SetActive(true);

        if (col.CompareTag("Narrator3"))
            CanvasNarrator[2].SetActive(true);

        if (col.CompareTag("Narrator4"))
            CanvasNarrator[3].SetActive(true);

        if (col.CompareTag("Narrator5"))
            CanvasNarrator[4].SetActive(true);


        if (col.tag==("Hearth"))
        {
            healthPoints += 1;

            Destroy(col.gameObject);
        }

        if (col.CompareTag("Goblin"))
        {

            if (healthPoints > 0)
            {
                anim.SetTrigger("isHurting");
                audioSource[3].Play();
                StartCoroutine("Hurt");
            }
        }

        if (col.CompareTag("Fire"))
        {
            healthPoints -= 1;

            if (healthPoints > 0)
            {
                anim.SetTrigger("isHurting");
                audioSource[3].Play();
                StartCoroutine("Hurt");
            }


            if (healthPoints == 0)
            {
                dirX = 0;
                anim.SetTrigger("isDead");
                LevelControlScript.instance.youLose();
            }
        }
    }

    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }

}
