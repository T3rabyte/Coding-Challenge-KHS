using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody rBody;

    public void Throw() 
    {
        gameObject.transform.parent = null;
        rBody.isKinematic = false;
        rBody.useGravity = true;
        rBody.velocity = gameObject.transform.forward * 20;
    }
}
