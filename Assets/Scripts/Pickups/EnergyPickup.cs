using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule"))
        {
            ResourceManagerFuture.Instance.PickUp();
            Destroy(this.gameObject.transform.parent.gameObject, 0.05f);
        }
    }
}
