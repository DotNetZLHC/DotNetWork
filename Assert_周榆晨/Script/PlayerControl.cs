using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private CircleCollider2D cir;
    private Animator animator;
    public LayerMask ground;

    public float speed;       //移动速度
    public float jumpforce;    //跳跃力

    private bool isHurt;    //受伤

    public Transform CellingCheck, GroundCheck;
    private bool isCell;
    private bool isGround;

    private int extraJump;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        cir = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        speed = 10;
        jumpforce = 10;

        GameObject.Find("Canvas/Text").GetComponent<Text>().text = PlayerPrefs.GetString("name", "天猫精灵");
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ground);

        if (!isHurt) {
            Move();
            Jump();
            Crouch();
        }
        AniamtionChange();
        
    }
    void Jump()
    {
        if (isGround)
        {
            extraJump = 1;
        }
        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rbody.velocity = Vector2.up * jumpforce;
            extraJump = extraJump-1;
            animator.SetBool("jumping", true);
        }
     /*   if (Input.GetButtonDown("Jump") && isGround && extraJump == 0)
        {
            rbody.velocity = Vector2.up * jumpforce;
            animator.SetBool("jumping", true);
        }*/
    }

    void Crouch()
    {
        if (!Physics2D.OverlapCircle(CellingCheck.position, 0.2f, ground)) {
            if (Input.GetButtonDown("Crouch"))
            {
                animator.SetBool("crouching", true);
                coll.enabled = false;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                animator.SetBool("crouching", false);
                coll.enabled = true;
            }
        }
    }

    void Move()
    {
        //水平移动
        float horizontalmove = Input.GetAxis("Horizontal"); ;
        float face = Input.GetAxisRaw("Horizontal");

        if (horizontalmove != 0)
        {
            rbody.velocity = new Vector2(horizontalmove * speed, rbody.velocity.y);
            animator.SetFloat("running", Mathf.Abs(face));
        }

        if (face != 0)
        {
            transform.localScale = new Vector3(face, 1, 1);
        }

        /* //跳跃
         if (Input.GetButtonDown("Jump") && cir.IsTouchingLayers(ground))
         {
             rbody.velocity = new Vector2(rbody.velocity.x, jumpforce);
             animator.SetBool("jumping", true);
         }*/
    }

    void AniamtionChange()
    {
        animator.SetBool("idle", false);
        if (rbody.velocity.y < 0.1 && !coll.IsTouchingLayers(ground))
        {
            animator.SetBool("falling", true);
        }
        if (animator.GetBool("jumping"))
        {
            if (rbody.velocity.y < 0)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
            }
        }
        else if (isHurt)
        {
            if (Mathf.Abs(rbody.velocity.x) < 0.1f)
            {
                isHurt = false;
            }
        }
        else if (cir.IsTouchingLayers(ground) || coll.IsTouchingLayers(ground))
        {
            animator.SetBool("falling", false);
            animator.SetBool("idle", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collection")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "deadline" || collision.tag == "trap")
        {
            Dead dead = collision.gameObject.GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
            // Invoke("reStart", 1f);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            animator.SetBool("climbing", false);
            rbody.gravityScale = 2;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Eagle")
        {
            if (animator.GetBool("falling"))
            {
                Destroy(collision.gameObject);
                rbody.velocity = new Vector2(rbody.position.x, jumpforce);
                animator.SetBool("jumping", true);
            }
            else
            {
                isHurt = true;
            }
        }
        if (collision.gameObject.tag == "SpringPlate")
        {
            rbody.velocity = new Vector2(rbody.position.x, jumpforce * 2.3f);
        }
        if (collision.gameObject.tag == "opossum" || collision.gameObject.tag=="trap")
        {
            this.gameObject.SetActive(false);
            Dead dead = GameObject.Find("deadline").GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            onLadder();
        }
    }
    public void onLadder()
    {
        animator.SetBool("climbing", true);
        float verticalMove = Input.GetAxis("Vertical"); ;
        if (verticalMove!=0)
        {
            rbody.gravityScale = 0;
            rbody.velocity = new Vector2(rbody.velocity.x, verticalMove);
        }
    }

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.GetComponent<AudioSource>().enabled = true;
    }

    public void Deliver(Transform trans)
    {
        rbody.position = new Vector2(trans.position.x, trans.position.y);
    }
}
