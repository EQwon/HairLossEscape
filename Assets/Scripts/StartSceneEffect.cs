using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;

    public void CreateEffect()
    {
        Instantiate(effect, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
