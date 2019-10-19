using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneDirection : MonoBehaviour
{
    [SerializeField] private int laneNum;

    public Vector2 Dir()
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
