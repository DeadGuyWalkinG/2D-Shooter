using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jump = 10f;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float jumpRate = 1f;
    private float nextFire = 0f;
    private float nextJump = 0f;
    [SerializeField]
    private Rigidbody2D playerRB;
    [SerializeField]
    private GameObject bullet;
    private int aim = 1;         //1 - right & 0 - left
    [SerializeField]
    private float offset = 8.41f;
    public Animator animator;
    private float horizontalMove;

    void Start()
    {
        
    }


    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        movement();

        if ((Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
            fire();
        
    }

    void movement()
    {
        if (horizontalMove < -0.4/*(Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A))*/)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            aim = 0;
        }
        else if (horizontalMove > 0.4/*(Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D))*/)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            aim = 1;
        }
        if (Input.GetAxis("Vertical")>0 && Time.time > nextJump)
        {
            playerRB.linearVelocityY = jump;
            nextJump = Time.time + jumpRate;
        }

        if (transform.position.x <= -offset)
            transform.position = new Vector2(-offset, transform.position.y);
        else if (transform.position.x >= offset)
            transform.position = new Vector2(offset, transform.position.y);
    }
    void fire()
    {
        if (aim == 1)
            Instantiate(bullet, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
        else
            Instantiate(bullet, new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);
        nextFire = Time.time + fireRate;
        Debug.Log("Bullet fired");
    }

    public int getAim()
    {
        return aim;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Player Destroyed");
            FindAnyObjectByType<LogicScript>().gameOver();
        }
    }
}


