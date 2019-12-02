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
        GameObject t1 = Instantiate(pastPrefab, positionInPast, Quaternion.identity);
        GameObject t2 = Instantiate(futurePrefab, positionInPast + offset, Quaternion.identity);
        if (!facesRight)
        {
            t1.transform.Rotate(new Vector3(0f, 180f, 0f));
            t2.transform.Rotate(new Vector3(0f, 180f, 0f));
        }
    }
}
