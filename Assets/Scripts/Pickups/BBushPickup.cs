using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBushPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            ResourceManagerPast.Instance.PickUp("bush");
            Destroy(this.gameObject.transform.parent.gameObject, 0.2f);
        }
    }
}
