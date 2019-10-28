using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] private int numberOfSegments;
    [SerializeField] private GameObject segmentPrefab;
    [SerializeField] private float offset = 1.5f;

    private GameObject prevSeg = null;
    private float currentOffset = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {
            GameObject seg = Instantiate(segmentPrefab, this.transform.position, Quaternion.identity);
            seg.transform.parent = this.transform;
            //seg.transform.localPosition = Vector3.zero;
            currentOffset += offset;
            seg.transform.position += new Vector3(0f, -currentOffset, 0f);
            if (!(prevSeg is null || prevSeg == null || prevSeg.Equals(default(Transform))))
                seg.transform.parent = prevSeg.transform;
            prevSeg = seg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
