using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterArrange : MonoBehaviour
{
    [SerializeField] private LayerMask contactLayer;
    private MonsterMove mover;
    
    private void Start()
    {
        mover = GetComponent<MonsterMove>();
        mover.enabled = false;
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.back);

        if (hit.Length > 0)
        {
            GameObject targetPosition = hit[0].transform.gameObject;
            Debug.Log(targetPosition.name + "에 배치했습니다." + targetPosition.transform.position);

            transform.position = targetPosition.transform.position;
            mover.enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
        }
        else
        {
            BoardManager.instance.ReturnEnergy(GetComponent<MonsterAI>().Cost);
            Destroy(gameObject);
        }
    }
}
