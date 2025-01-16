using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int aim = 0;
    [SerializeField]
    private float speed = 7.5f;
    [SerializeField]
    private float offset = 8.41f;
    void Start()
    {
  
    }

   
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (transform.position.x <= -offset)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            aim = 1;
        }
        else if (transform.position.x >= offset)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            aim = 0;
        }

        if (aim == 0)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            FindAnyObjectByType<LogicScript>().increaseScore();
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
        }

    }
}
