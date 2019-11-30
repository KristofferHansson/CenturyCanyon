using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTreePickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            ResourceManagerPast.Instance.PickUp("tree");
            Destroy(this.gameObject.transform.parent.gameObject, 0.2f);
        }
    }
}
