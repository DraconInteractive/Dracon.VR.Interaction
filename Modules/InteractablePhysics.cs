using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePhysics : InteractableModule
{
    Rigidbody rb;

    public bool throwOnRelease;
    public float throwForce = 1;

    public override void Setup(Interactable _target)
    {
        base.Setup(_target);

        rb = GetComponent<Rigidbody>();

        target.onGrab.AddListener(OnGrab);
        target.onRelease.AddListener(OnRelease);
    }

    public override void OnDestroyEx()
    {
        base.OnDestroyEx();

        target.onGrab.RemoveListener(OnGrab);
        target.onRelease.RemoveListener(OnRelease);
    }

    void OnGrab ()
    {
        rb.isKinematic = true;
    }

    void OnRelease ()
    {
        rb.isKinematic = false;
        
        if (throwOnRelease)
        {
            //rb.velocity *= 2.5f;
            //rb.angularVelocity *= 2.5f;
            rb.velocity = target.interactor.Velocity * throwForce;
        }
    }
}
