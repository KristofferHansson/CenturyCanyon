using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour
{
    public float TimeBeforeDestruction = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("destroyBlock", TimeBeforeDestruction);
    }

    private void destroyBlock()
    {
        Destroy(this.gameObject);
    }
}
