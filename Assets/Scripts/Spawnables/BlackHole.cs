using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float PullDistance = 5.0f;

    public float PullForce = 20.0f;

    public bool activated = true;

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public void toggleActivate()
    {
        activated = !activated;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 8f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PullDistance);
        foreach (var collider in colliders)
        {
            if ((collider.name == "P1Capsule" || collider.name == "P2Capsule") && (activated))
            {
                Vector3 direction = transform.position - collider.transform.position;
                float distance = direction.sqrMagnitude;
                collider.GetComponentInParent<Rigidbody>().AddForce(direction * PullForce);
            }
        }
    }
}
