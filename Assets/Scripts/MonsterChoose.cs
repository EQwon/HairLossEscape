using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterChoose : MonoBehaviour
{
    public GameObject monster;
    [SerializeField] private int cost;

    private bool canSpawn = false;

    private void Start()
    {
        GetComponent<Image>().sprite = monster.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Image>().SetNativeSize();

        cost = monster.GetComponent<MonsterAI>().Cost;
    }

    private void Update()
    {
        if (BoardManager.instance.MyEnergy >= cost)
        {
            GetComponent<Image>().color = Color.white;
            canSpawn = true;
        }
        else
        {
            GetComponent<Image>().color = Color.grey;
            canSpawn = false;
        }
    }

    public void SelectMonster()
    {
        if (!canSpawn) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(monster, mousePos, Quaternion.identity);
        BoardManager.instance.UseEnergy(cost);
    }
}