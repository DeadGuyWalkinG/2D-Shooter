using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bulletRB;
    [SerializeField]
    private float speed = 10f;
    private int aim;
    [SerializeField]
    private float offset = 10f;

    void Start()
    {
        aim = FindAnyObjectByType<PlayerScript>().getAim();
        transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (aim==1)
            bulletRB.linearVelocity = Vector2.right*speed;
        else 
            bulletRB.linearVelocity = Vector2.left*speed;

        if (transform.position.x > offset || transform.position.x < -offset)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
