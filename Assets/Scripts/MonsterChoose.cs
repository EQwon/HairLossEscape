using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterChoose : MonoBehaviour
{
    public GameObject monster;

    private void Start()
    {
        GetComponent<Image>().sprite = monster.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Image>().SetNativeSize();
    }

    public void SelectMonster()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(monster, mousePos, Quaternion.identity);
    }
}