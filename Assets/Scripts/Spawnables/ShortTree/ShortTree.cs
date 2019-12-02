using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTree : MonoBehaviour, ISpawnable
{
    [SerializeField] private GameObject pastPrefab;
    [SerializeField] private GameObject futurePrefab;

    public void Spawn(Vector3 positionInPast, Vector3 offset, bool facesRight = true)
    {
        //past.transform.position = positionInPast;
        //future.transform.position = positionInPast + offset;

        Quaternion rot = Quaternion.identity;
        if (!facesRight)
        {
            rot = Quaternion.Euler(0f, 180f, 0f);
        }

        GameObject t1 = Instantiate(pastPrefab, positionInPast, rot);
        GameObject t2 = Instantiate(futurePrefab, positionInPast + offset, rot);
    }
}
