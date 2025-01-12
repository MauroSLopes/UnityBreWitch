using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeEnemyBehavior : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    GameObject player;
    Animator animator;

    private float speed;

    private Vector2 nextPos;

    private bool inCooldown = false;

    void Start()
    {
        speed = gameObject.GetComponent<EnemyStatus>().speed;
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        enemyRigidBody = GetComponent<Rigidbody2D>();

        StartCoroutine(MoveEnemy());
    }

    void Update()
    {
        if (!inCooldown) {
            transform.Translate(nextPos.normalized * Time.deltaTime * speed);

            if (speed == 0)
            {
                return;
            }

            animator.SetBool("Jump", true);
        }

        if (gameObject.transform.position.x <= -13f || gameObject.transform.position.x >= 13f)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y <= -8f || gameObject.transform.position.y >= 8f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator MoveEnemy()
    {
        while (true) {
            speed = gameObject.GetComponent<EnemyStatus>().speed;
            nextPos = player.transform.position - transform.position;
            inCooldown = false;
            yield return new WaitForSeconds(0.25f);
            inCooldown = true;
            animator.SetBool("Jump", false);
            yield return new WaitForSeconds(1f);
        }
    }
}
