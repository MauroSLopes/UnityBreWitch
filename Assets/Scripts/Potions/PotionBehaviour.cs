using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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

    public GameObject[] GetEnemys()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void ChangeEnemySpeed(float value)
    {
        var Enemys = GetEnemys();

        foreach(var Enemy in Enemys)
        {
            Enemy.GetComponent<EnemyStatus>().speed = value;
        }
    }

    public void KillAllEnemys()
    {
        var Enemys = GetEnemys();

        foreach (var Enemy in Enemys)
        {
            GameObject.Destroy(Enemy);
        }
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
}
