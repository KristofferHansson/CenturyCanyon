using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTree : MonoBehaviour, ISpawnable
{
    [SerializeField] private GameObject pastPrefab;
    [SerializeField] private GameObject futurePrefab;

    public void Spawn(Vector3 positionInPast, Vector3 offset)
    {
        //past.transform.position = positionInPast;
        //future.transform.position = positionInPast + offset;
        Instantiate(pastPrefab, positionInPast, Quaternion.identity);
        Instantiate(futurePrefab, positionInPast + offset, Quaternion.identity);
    }
}
