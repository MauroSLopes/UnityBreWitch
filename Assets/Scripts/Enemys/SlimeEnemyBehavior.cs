using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyBehavior : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    GameObject player;

    [SerializeField] float speed = 10f;

    private Vector2 nextPos;

    private bool inCooldown = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyRigidBody = GetComponent<Rigidbody2D>();

        StartCoroutine(MoveEnemy());
    }

    void Update()
    {
        if (!inCooldown) {
            transform.Translate(nextPos.normalized * Time.deltaTime * speed);
            }
    }

    IEnumerator MoveEnemy()
    {
        while (true) {
            nextPos = player.transform.position - transform.position;
            inCooldown = false;
            yield return new WaitForSeconds(0.25f);
            inCooldown = true;
            yield return new WaitForSeconds(1f);
        }
    }
}
