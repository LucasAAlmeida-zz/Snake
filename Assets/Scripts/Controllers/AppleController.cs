using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    readonly float range = 4.5f;

    public void MoveApple()
    {
        var posX = Random.Range(-range, range);
        var posZ = Random.Range(-range, range);
        transform.position = new Vector3(posX, 0.25f, posZ);
    }
}
