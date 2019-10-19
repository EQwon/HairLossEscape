using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private float myEnergy;
    [Tooltip("초당 충전되는 에너지")]
    [SerializeField] private float chargeSpeed = 5f;

    [SerializeField] private int myPoint = 0;

    public static BoardManager instance;
    public float MyEnergy { get { return myEnergy; } }
    public float MyPoint { get { return myPoint; } }

    private float nowTime = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        myEnergy = 0;
    }

    private void FixedUpdate()
    {
        float target = myEnergy + chargeSpeed * Time.fixedDeltaTime;
        if (target >= maxEnergy)
        {
            target = maxEnergy;
        }

        myEnergy = target;
    }

    public void UseEnergy(int energy)
    {
        myEnergy -= energy;
    }

    public void ReturnEnergy(int amount)
    {
        myEnergy += amount;
    }

    public void GetPoint(int amount)
    {
        myPoint += amount;

        if (myPoint >= 100)
        {
            Debug.LogError("게임 승리!");
        }
    }
}
