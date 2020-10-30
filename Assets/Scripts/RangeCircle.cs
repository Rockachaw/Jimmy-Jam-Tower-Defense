using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    public void MoveRangeCircle(float x, float y, float range)
    {
        transform.position = new Vector3(x, y, 0);
        float scale = range * 11f;
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
