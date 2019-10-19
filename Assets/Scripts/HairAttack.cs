using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAttack : MonoBehaviour
{
    [SerializeField] private WeaponDelay delay;
    [SerializeField] private int damage = 10;
    [SerializeField] private bool canAttack = true;

    private bool doingAttack = false;
    private GameObject myTarget;

    private void Update()
    {
        if (doingAttack)
        {
            DoAttack();
        }
    }

    public void DoAttack()
    {
        if (myTarget)
            myTarget.GetComponent<MonsterAI>().GetDamage(damage);
    }

    public void TryAttack(GameObject target)
    {
        if (canAttack)
        {
            myTarget = target;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        if (canAttack == false) yield break;

        canAttack = false;

        yield return new WaitForSeconds(delay.pre);

        doingAttack = true;

        yield return new WaitForSeconds(delay.attack);

        doingAttack = false;

        yield return new WaitForSeconds(delay.post);

        canAttack = true;
    }
}
