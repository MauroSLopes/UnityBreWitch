using System.Collections;
using UnityEngine;

public class PotionBehaviour
{
    private GameObject playerGameObject;
    private PlayerStatus playerStatus;

    public PotionBehaviour(GameObject gameObject)
    {
        this.playerGameObject = gameObject;
        playerStatus = playerGameObject.GetComponent<PlayerStatus>();
    }

    public void ChangePlayerHealth(int value)
    {
        playerStatus.playerHealth = value;
    }

    public void ChangePlayerSpeed(float value)
    {
        playerStatus.playerMoveSpeed = value;
    }

    public GameObject[] GetByTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public void ChangeEnemySpeed(float value)
    {
        var Enemys = GetByTag("Enemy");

        foreach(var Enemy in Enemys)
        {
            Enemy.GetComponent<EnemyStatus>().speed = value;
        }
    }

    public void KillAllEnemys()
    {
        var Enemys = GetByTag("Enemy");

        foreach (var Enemy in Enemys)
        {
            GameObject.Destroy(Enemy);
        }
    }

    public void DestroyAllObstacles()
    {
        foreach(GameObject obstacle in GetByTag("Obstacle"))
        {
            GameObject.Destroy(obstacle);
        }
    }

    public void ToggleCollider(GameObject collider)
    {
        collider.GetComponent<CircleCollider2D>().enabled = !collider.GetComponent<CircleCollider2D>().enabled;
    }

    public IEnumerator ToggleCollider(GameObject collider, float duration)
    {
        ToggleCollider(collider);
        yield return new WaitForSeconds(duration);
        ToggleCollider(collider);
    }

    public Vector2 ChangePlayerHitBox(Vector2 hitboxSize)
    {
        Vector2 oldHitBoxSize = playerGameObject.GetComponent<BoxCollider2D>().size;
        playerGameObject.GetComponent<BoxCollider2D>().size = hitboxSize;
        playerGameObject.GetComponent<SpriteRenderer>().enabled = !playerGameObject.GetComponent<SpriteRenderer>().enabled;

        return oldHitBoxSize;
    }

    public IEnumerator TemporaryMovespeed(float BonusMovespeed, float duration, int type)
    {
        float defaultMoveSpeed;

        if (type == 0)
        {
            defaultMoveSpeed = playerStatus.playerMoveSpeed;
            ChangePlayerSpeed(BonusMovespeed);

        } else
        {
            defaultMoveSpeed = 10f;
            ChangeEnemySpeed(BonusMovespeed);
        }

        yield return new WaitForSeconds(duration);

        if (type == 0)
        {
            ChangePlayerSpeed(defaultMoveSpeed);
        }
        else
        {
            ChangeEnemySpeed(defaultMoveSpeed);
        }
    }

    public IEnumerator tinyPotionBehavior(Vector2 hitboxSize, float duration, GameObject tinyPlayer)
    {
        Vector2 oldHitBoxSize = ChangePlayerHitBox(hitboxSize);
        tinyPlayer.SetActive(true);

        yield return new WaitForSeconds(duration);

        tinyPlayer.SetActive(false);
        ChangePlayerHitBox(oldHitBoxSize);
    }


}
