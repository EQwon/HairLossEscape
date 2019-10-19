using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairStatus : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int nowHealth;

    private void Start()
    {
        nowHealth = maxHealth;
    }

    public void GetDamage(int amount)
    {
        nowHealth -= amount;
        Debug.Log("머리카락이 " + amount + "만큼의 데미지를 받았습니다.");

        if (nowHealth <= 0)
        {
            Debug.Log(name + "죽었습니다.");
            Destroy(gameObject);
        }
    }
}
