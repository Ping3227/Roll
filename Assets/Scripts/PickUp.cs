using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUp : MonoBehaviour
{
    [SerializeField] private SwitchMaterial visitor;
    [SerializeField] bool destoryOnPickup = true;

    private void OnTriggerEnter(Collider other)
    {
        var visitable = other.GetComponent<IVisitable>();
        if(visitable != null)
        {
            visitable.Accept(visitor);
            if (destoryOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }
}