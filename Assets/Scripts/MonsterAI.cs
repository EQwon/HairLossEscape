using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState { Walk, Attack }

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private MonsterState state = MonsterState.Walk;
    [SerializeField] private int maxHealth;
    [SerializeField] private int nowHealth;
    [SerializeField] private int cost;
    private MonsterMove mover;
    private MonsterAttack attacker;
    private GameObject targetHair;

    public int Cost { get { return cost; } }

    private void Start()
    {
        attacker = GetComponent<MonsterAttack>();
        mover = GetComponent<MonsterMove>();

        nowHealth = maxHealth;
    }

    private void Update()
    {
        switch (state)
        {
            case MonsterState.Attack:
                attacker.TryAttack(targetHair);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Hair")
        {
            mover.CanMove = false;
            state = MonsterState.Attack;
            targetHair = coll.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Hair")
        {
            mover.CanMove = true;
            targetHair = null;
        }
    }

    public void GetDamage(int amount)
    {
        nowHealth -= amount;
        Debug.Log(name + "이 " + amount + "만큼의 데미지를 받았습니다.");

        if (nowHealth <= 0)
        {
            Debug.Log(name + "죽었습니다.");
            Destroy(gameObject);
        }
    }
}
