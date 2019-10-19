using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection { Horizontal, Vertical }

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canMove = true;

    private Vector2 moveDir = new Vector2(0, 1);
    private SpriteRenderer sr;

    public bool CanMove { set { canMove = value; } }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        sr.sortingOrder = 1000 - (int)(transform.position.y * 100);
        if (canMove)
        {
            transform.position += (Vector3)moveDir * speed * Time.fixedDeltaTime;
            canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "End")
        {
            Destroy(gameObject);
        }
    }
}
