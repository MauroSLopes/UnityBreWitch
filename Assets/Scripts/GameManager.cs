using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerGameObject;
    private PotionBehaviour testing;


    private void Start()
    {
        testing = new PotionBehaviour(PlayerGameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            testing.KillAllEnemys();
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            testing.ChangeEnemySpeed(-2f);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            testing.ChangePlayerSpeed(3f);
        }
    }
}
