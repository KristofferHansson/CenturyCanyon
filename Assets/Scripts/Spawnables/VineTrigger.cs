using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTrigger : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            player = other.gameObject.transform.parent.gameObject;
            Invoke("StopMotion", 0.1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            StartMotion();
        }
    }

    private void StopMotion()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
    }

    private void StartMotion()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = true;
        player = null;
    }
}
