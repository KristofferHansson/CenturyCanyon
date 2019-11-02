using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private L00_MechanicsTestbed lvl;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule") || other.gameObject.name.Equals("P1Capsule"))
        {
            lvl.PlayerIn();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule") || other.gameObject.name.Equals("P1Capsule"))
        {
            lvl.PlayerOut();
        }
    }
}
