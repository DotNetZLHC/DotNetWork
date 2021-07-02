using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCon : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator Anim;
    public float speed;
    public float verticalSpeed;
    public float jumpforce;
    public LayerMask ground;
    public LayerMask eagle;
    public LayerMask ladder;
    public Collider2D coll;
    public int cherry = 0;
    public Text CherryNum;
    private bool isHurt = false;
    public AudioSource jumpAudio;
    public AudioSource getAudio;
    public AudioSource hurtAudio;
    public AudioSource fallAudio; 
    public AudioSource failAudio;
    public AudioSource firstBGM;
    public AudioSource secondBGM;

    public Collider2D closeColl;
    public Transform ceilingCheck,groundCheck;
    private bool checkhead = false;
    private bool isGround;
    private float horizontalMove;
    private float verticalMove;
    public Image cdImage;
    private float facedirection;
    public GameObject button;

    public GameObject clockPanel;

    private bool usingClock = false;

    public float dashTime;
    private float dashTimeLeft;
    private float lastDash = -10f;
    public float dashCoolDown;
    public float dashSpeed;

    public GameObject diedPanel;
    private float timeRecord;

    public bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);

        Dash();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                ReadyToDash();
            }
        }
        if (isDashing)
        {
            return;
        }

        if (!isHurt)
        {
            Movement();
        }

        SwitchAnim();

        cdImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
    }


    void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        
        facedirection = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0)
        {
            /*if (Anim.GetBool("jumping") || Anim.GetBool("falling"))
            {

            }
            else*/
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }
        Anim.SetFloat("running", Mathf.Abs(facedirection));
        if (facedirection != 0)
        {
            /*if (Anim.GetBool("jumping") || Anim.GetBool("falling"))
            {

            }else*/
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && (coll.IsTouchingLayers(ground)||coll.IsTouchingLayers(eagle)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            //jumpAudio.Play();
            //SoundManager.instance.JumpAudio();
            Anim.SetBool("jumping", true);
            Anim.SetBool("idling", false);
        }

        Crouch();
    }

    void SwitchAnim()
    {
        if (rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground) && !coll.IsTouchingLayers(eagle)&&!coll.IsTouchingLayers(ladder))
        {
            fallAudio.Play();
            Anim.SetBool("falling", true);
        }
        if (Anim.GetBool("jumping"))
        {
            Anim.SetBool("falling", false);
            if (rb.velocity.y < 0)
            {
                Anim.SetBool("jumping", false);
                fallAudio.Play();
                Anim.SetBool("falling", true);
            }

        }
        else if (isHurt)
        {
            Anim.SetBool("hurting", true);
            if (Mathf.Abs(rb.velocity.x) < 1f)
            {
                isHurt = false;
                Anim.SetBool("hurting", false);
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            Anim.SetBool("falling", false);
            Anim.SetBool("idling", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "clockUsingArea"&&usingClock)
        {
            clockPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject goj = collision.gameObject;
                goj.SendMessage("TrapUsingClock");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        verticalMove = Input.GetAxis("Vertical");
        if (collision.tag == "collection")
        {
            collision.tag = "Untagged";
            getAudio.Play();
            collision.GetComponent<Animator>().Play("getCherry");
            //Destroy(collision.gameObject);
            //cherry += 1;
            CherryNum.text = (cherry+1).ToString();
        }
        if (collision.tag == "dealine")
        {
            //GetComponent<AudioSource>().enabled = false;
            pauseMusic();
            //failAudio.Play();
            button.SetActive(false);
            diedPanel.SetActive(true);
            //Invoke("resetScene",2);
        }
        if (collision.tag == "trapToDie")
        {
            Time.timeScale = 0.4f;
            Invoke("resetTime", 1);
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(-10, rb.velocity.y + 2);
            }
            else if (transform.position.x >= collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(10, rb.velocity.y + 2);
            }
            pauseMusic();
            diedPanel.SetActive(true);
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clockPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trapBlock")
        {
            Time.timeScale = 0.4f;
            Invoke("resetTime", 1);
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(-10, rb.velocity.y + 2);
            }
            else if (transform.position.x >= collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(10, rb.velocity.y + 2);
            }
            pauseMusic();
            button.SetActive(false);
            diedPanel.SetActive(true);
        }
        if (Anim.GetBool("falling"))
        {
            if (collision.gameObject.tag == "eagle")
            {
                Anim.SetBool("falling", false);
                Anim.SetBool("idling", true);
            }
        }
        else if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "eagle")
        {
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(-10, rb.velocity.y + 2);
            }
            else if (transform.position.x >= collision.gameObject.transform.position.x)
            {
                isHurt = true;
                hurtAudio.Play();
                rb.velocity = new Vector2(10, rb.velocity.y + 2);
            }
        }
    }

    void Crouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            closeColl.enabled = false;
            Anim.SetBool("crouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            checkhead = true;
        }
        if (checkhead)
        {
            if (!Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, ground))
            {
                closeColl.enabled = true;
                Anim.SetBool("crouching", false);
                checkhead = false;
            }
        }
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addCherry()
    {
        ++cherry;
    }

    public void pauseMusic()
    {
        GetComponent<AudioSource>().enabled = false;
    }

    public void resumeMusic()
    {
        GetComponent<AudioSource>().enabled = true;
    }

    void ReadyToDash()
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;

        cdImage.fillAmount = 1;
    }

    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                shadowPool.instance.GetFromPool();
            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
            }
        }
        
    }

    void onLadder(bool flag)
    {
        Anim.SetBool("onLadder", flag);
    }

    void resetTime()
    {
        Time.timeScale = 1f;
    }

    public void clockOn()
    {
        firstBGM.Stop();
        secondBGM.Play();
        usingClock = true;
    }
}
