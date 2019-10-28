using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoConnectHingeJoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!(transform.parent is null || transform.parent == null || transform.parent.Equals(default(Transform))))
            GetComponent<HingeJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
    }
}
