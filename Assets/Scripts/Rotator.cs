using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float mps = 45.0f;
    ///<summary> Start should be called before first frame</summary>
    void Start()
    {
    }

    ///<summary> Once per frame update, I hope, causing coin to spin</summary>
    void Update()
    {
        transform.Rotate(mps * Time.deltaTime, 0, 0);
    }
}