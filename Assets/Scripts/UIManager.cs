using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Slider energySlider;
    [SerializeField] private Slider pointSlider;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        energySlider.value = BoardManager.instance.MyEnergy;
        pointSlider.value = BoardManager.instance.MyPoint;
    }
}
