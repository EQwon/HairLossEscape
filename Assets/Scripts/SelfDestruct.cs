using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float time;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
