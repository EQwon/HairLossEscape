using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private float myEnergy;
    [Tooltip("초당 충전되는 에너지")]
    [SerializeField] private float chargeSpeed = 5f;

    public static BoardManager instance;
    public float MyEnergy { get { return myEnergy; } }
    public float NowTime { get { return nowTime; } }

    private float nowTime = 60f;

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
        nowTime -= Time.fixedDeltaTime;
        float target = myEnergy + chargeSpeed * Time.fixedDeltaTime;
        if (target >= maxEnergy)
        {
            target = maxEnergy;
        }

        myEnergy = target;
        
        if (nowTime <= 0)
        {
            nowTime = 0;

            UIManager.instance.Lose();
        }
    }

    public void UseEnergy(int energy)
    {
        myEnergy -= energy;
    }

    public void ReturnEnergy(int amount)
    {
        myEnergy += amount;
    }
}
