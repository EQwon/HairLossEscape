using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lane
{
    public List<GameObject> hair;
}

public class BoardManager : MonoBehaviour
{
    public List<Lane> lanes = new List<Lane>();

    [SerializeField] private List<GameObject> hairPrefabs;
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private float myEnergy;
    [Tooltip("초당 충전되는 에너지")]
    [SerializeField] private float chargeSpeed = 5f;

    [SerializeField] private int myPoint = 0;

    [Tooltip("머리카락 하나 생성할 때까지 걸리는 시간")]
    [SerializeField] private float spawnSpeed = 3f;

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

        SpawnInitialHair();
    }

    private void FixedUpdate()
    {
        nowTime += Time.fixedDeltaTime;
        float target = myEnergy + chargeSpeed * Time.fixedDeltaTime;
        if (target >= maxEnergy)
        {
            target = maxEnergy;
        }

        myEnergy = target;

        if(nowTime >= spawnSpeed)
        {
            SpawnRandomHair();
            nowTime = 0;
        }
    }

    private void SpawnInitialHair()
    {
        for (int i = 0; i < lanes.Count; i++)
        {
            for(int j = 0; j < lanes[i].hair.Count; j++)
            {
                if (lanes[i].hair[j] == null) continue;

                GameObject target = lanes[i].hair[j];

                lanes[i].hair[j] = Instantiate(target, SpawnPos(i, j), Quaternion.identity, transform);
            }
        }
    }

    private int GetLaneValue(int laneNum)
    {
        Lane targetLane = lanes[laneNum];
        int totalValue = 0;

        for (int i = 0; i < targetLane.hair.Count; i++)
        {
            if (targetLane.hair[i])
            {
                totalValue += targetLane.hair[i].GetComponent<HairAI>().Value;
            }
        }

        return totalValue;
    }

    private int GetMinimumValueLaneNum()
    {
        int minLaneNum = -1;
        int minValue = 99999;

        for (int i = 0; i < lanes.Count; i++)
        {
            int nowLaneValue = GetLaneValue(i);
            if (minValue > nowLaneValue)
            {
                minValue = nowLaneValue;
                minLaneNum = i;
            }
        }

        return minLaneNum;
    }

    private void SpawnRandomHair()
    {
        int laneNum = GetMinimumValueLaneNum();

        if (SpawnLanePos(laneNum).HasValue == false) return;

        int spawnVerticalPos = SpawnLanePos(laneNum).Value;
        int hairNum = Random.Range(0, hairPrefabs.Count);

        lanes[laneNum].hair[spawnVerticalPos] = Instantiate(hairPrefabs[hairNum], SpawnPos(laneNum, spawnVerticalPos), Quaternion.identity);
    }

    private Vector2 SpawnPos(int x, int y)
    {
        return new Vector2(-2.5f + x, 3 - y) - Dir(x) * y / 2;
    }

    private int? SpawnLanePos(int laneNum)
    {
        for(int i = 0; i < lanes[laneNum].hair.Count; i++)
        {
            if (lanes[laneNum].hair[i] == null)
                return i;
        }

        return null;
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

    private Vector2 Dir(int laneNum)
    {
        switch (laneNum)
        {
            case 0:
                return (new Vector2(1.5f, 6f)).normalized;
            case 1:
                return (new Vector2(0.9f, 6f)).normalized;
            case 2:
                return (new Vector2(0.3f, 6f)).normalized;
            case 3:
                return (new Vector2(-0.3f, 6f)).normalized;
            case 4:
                return (new Vector2(-0.9f, 6f)).normalized;
            case 5:
                return (new Vector2(-1.5f, 6f)).normalized;
            default:
                return Vector2.zero;
        }
    }
}
