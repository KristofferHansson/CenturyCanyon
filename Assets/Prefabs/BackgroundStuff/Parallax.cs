using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject[] layers;
    [SerializeField] private float[] strengths;
    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = cam.transform.position;
    }

    void FixedUpdate()
    {
        float dist = cam.transform.position.x - prevPos.x; // x diff
        GameObject l;
        for (int i = 0; i < layers.Length; i++)
        {
            l = layers[i];

            l.transform.position -= new Vector3(dist * strengths[i], 0, 0);
        }
        prevPos = cam.transform.position;
    }
}
