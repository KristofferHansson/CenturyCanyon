using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L00_MechanicsTestbed : MonoBehaviour, ILevelScript
{
    [SerializeField] private GameObject mapToCopy;
    [SerializeField] private GameObject p2Prefab;
    [SerializeField] private Transform p1Transform;
    [SerializeField] private int offset;

    // Start is called before the first frame update
    void Start()
    {
        GameObject p2Map = Instantiate(mapToCopy);
        p2Map.transform.position = mapToCopy.transform.position + new Vector3(offset, 0.0f, 0.0f);

        GameObject p2 = Instantiate(p2Prefab);
        p2.transform.position = p1Transform.position + new Vector3(offset, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetOffset()
    {
        return offset;
    }
}
