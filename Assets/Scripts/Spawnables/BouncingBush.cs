using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBush : MonoBehaviour
{
    Rigidbody prb = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule"))
        {
            prb = other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            Invoke("Launch", 0.4f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule"))
        {
            prb = null;
        }
    }

    private void Launch()
    {
        prb.AddForce(Vector3.up * 600.0f);
    }
}
