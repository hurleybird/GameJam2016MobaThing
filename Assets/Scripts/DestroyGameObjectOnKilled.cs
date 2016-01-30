using System;
using UnityEngine;

public class DestroyGameObjectOnKilled : MonoBehaviour
{
    public void Start()
    {
        gameObject.GetComponent<Health>().OnKilled += (_) => Destroy(gameObject);
    }

}

