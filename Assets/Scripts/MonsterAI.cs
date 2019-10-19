using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    private MonsterMove mover;
    private MonsterAttack attacker;
    private GameObject targetHair;

    private void Start()
    {
        attacker = GetComponent<MonsterAttack>();
        mover = GetComponent<MonsterMove>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("??");
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log(coll.name + "을 만났습니다.");
        if (coll.tag == "Hair")
        {
            mover.CanMove = false;
            attacker.TryAttack(coll.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("!!");
    }
}
