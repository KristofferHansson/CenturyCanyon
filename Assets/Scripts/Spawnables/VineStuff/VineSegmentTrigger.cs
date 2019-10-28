using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSegmentTrigger : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            player = other.gameObject.transform.parent.gameObject;
            PlayerController pc = player.GetComponent<PlayerController>();
            if (!pc.IsOnVine() && !pc.IsInVine())
            {
                pc.SetOnVine(this);
                StopMotion();
                HingeJoint hj = player.AddComponent<HingeJoint>();
                hj.connectedBody = this.GetComponent<Rigidbody>();
            }
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
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.VineExited();
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = true;
        player = null;
    }

    public void ReleasePlayer()
    {
        Destroy(player.GetComponent<HingeJoint>());
    }
}
