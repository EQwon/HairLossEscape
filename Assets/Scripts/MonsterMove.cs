using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection { Horizontal, Vertical }

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canMove = true;

    private Vector2 moveDir = new Vector2(0, 1);

    public bool CanMove { set { canMove = value; } }
    public Vector2 SetDir { set { moveDir = value; } }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += (Vector3)moveDir * speed * Time.fixedDeltaTime;
            canMove = true;
        }
    }
}
