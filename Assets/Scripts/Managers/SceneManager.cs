using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(applePrefab);
        applePrefab.GetComponent<AppleController>().MoveApple();
    }
}
