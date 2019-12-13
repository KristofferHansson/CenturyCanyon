using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxnew : MonoBehaviour
{
    public GameObject cam;
    public float parallaxVFX;
    private float length, startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxVFX);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
