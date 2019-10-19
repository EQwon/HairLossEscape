using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HairState { Normal, Attack }

public class HairAI : MonoBehaviour
{
    [SerializeField] private HairState state = HairState.Normal;
    [SerializeField] private int maxHealth;
    [SerializeField] private int nowHealth;
    [SerializeField] private int point;

    private HairAttack attacker;
    private GameObject targetMonster = null;

    private void Start()
    {
        attacker = GetComponent<HairAttack>();
        nowHealth = maxHealth;
    }

    private void Update()
    {
        switch (state)
        {
            case HairState.Attack:
                attacker.TryAttack(targetMonster);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Monster")
        {
            state = HairState.Attack;
            targetMonster = coll.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Monster")
        {
            targetMonster = null;
        }
    }

    public void GetDamage(int amount)
    {
        nowHealth -= amount;
        Debug.Log("머리카락이 " + amount + "만큼의 데미지를 받았습니다.");

        if (nowHealth <= 0)
        {
            Debug.Log(name + "죽었습니다.");
            BoardManager.instance.GetPoint(point);
            Destroy(gameObject);
        }
    }
}