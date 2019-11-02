using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // ILevelScript lvl;
    [SerializeField] private float riseRate = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // riseRate = lvl.riserate
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0f,riseRate,0f);
    }
}
