using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   [SerializeField]private Rigidbody2D rb;
   [SerializeField]private Animator anim;
    public AudioSource jumpAudio;
    public Collider2D disColl;
    public Transform cellingCheck;


    [Space]
    public float speed;
    public float jumpforce;
    public static bool key;
    public Collider2D coll;
    [Space]
    public LayerMask ground,ladder;
    public static int cherry,dimond;

    public Text CherryNum,DimondNum,KeyStatu;
    public bool isHurt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHurt)
        {
            Movement();
        }
        SwitchAnim();
    }

    void Movement()
    {
        float horizontalmove =  Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        //角色移动
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }
        if(facedirection != 0)
        {
            rb.transform.localScale = new Vector3(facedirection, 1, 1);
        }

        //角色跳跃
        if (Input.GetButtonDown("Jump")&& coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
            jumpAudio.Play();
        }

        Climb();
        Crouch();


    }
    //切换动画效果

    void SwitchAnim()
    {
       
        if(rb.velocity.y<0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", true);
        }

        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
        else if (isHurt)
        {
            anim.SetBool("hurt", true);
            anim.SetFloat("running", 0);
            if (Mathf.Abs(rb.velocity.x)< 0.1f){
                anim.SetBool("hurt", false);
                isHurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ladder))
        {
            anim.SetBool("climbing", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            cherry++;
            CherryNum.text = cherry.ToString(); 
        }
        if (collision.tag == "DeadLine")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);
        }
        if(collision.tag == "Dimonds")
        {
            Destroy(collision.gameObject);
            dimond++;
            DimondNum.text = dimond.ToString();
        }
        if(collision.tag == "Key")
        {
            Destroy(collision.gameObject);
            key = true;
            KeyStatu.text = "Get";

        }
    }

    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
           /* if (anim.GetBool("falling"))
            {
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
            }else*/ if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-3, rb.velocity.y);
                isHurt = true;
                GetComponent<AudioSource>().enabled = false;
                Invoke("Restart", 2f);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(3, rb.velocity.y);
                isHurt = true;
                GetComponent<AudioSource>().enabled = false;
                Invoke("Restart", 2f);
            }

        }
    }

     void Crouch()
     {
         if (!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground))
         {
             if (Input.GetButton("Crouch"))
             {
                 anim.SetBool("crouching", true);
                 disColl.enabled = false;
             }
             else
             {
                 anim.SetBool("crouching", false);
                 disColl.enabled = true;
             } 
         }
      }

    void Climb()
    {
        if (coll.IsTouchingLayers(ladder))
        {
            if (Input.GetButton("Crouch"))
            {
                anim.SetBool("climbing", true);
                rb.velocity = new Vector2(rb.velocity.x, -jumpforce);
            }
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("climbing", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        else
        {
            anim.SetBool("climbing", false);
        }
    }

    void Restart()
    {
       
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


}
