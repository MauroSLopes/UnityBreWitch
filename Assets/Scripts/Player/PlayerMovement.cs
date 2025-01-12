using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed;

    Rigidbody2D rb;

    HerbInventory inventory;

    PlayerStatus status;

    bool isFacingRight = false;
    internal Vector3 direction;

    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<HerbInventory>();
    }


    void Update()
    {
        playerSpeed = status.playerMoveSpeed;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }

        if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }

        transform.Translate(direction.normalized * Time.deltaTime * playerSpeed);

        if (transform.position.x < -10 || transform.position.x > 10)
        {
            if (isFacingRight)
            {
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
                return;
            }

            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -5.5f)
        {
                transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
        }

        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }


    void Flip()
    {
        Vector3 currentScale = transform.localScale;

        currentScale.x *= -1;

        transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            return;
        }

        HerbTypes herb = collision.GetComponent<HerbBehavior>().herbName;
        inventory.AddHerb(herb);

        Destroy(collision.gameObject);
    }
}
