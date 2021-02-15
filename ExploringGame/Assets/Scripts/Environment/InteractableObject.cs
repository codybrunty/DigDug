using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour{

    private Rigidbody rb;
    public bool hasGravity;
    public float forceStrength;
    public float randomRotationStrength;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (!hasGravity) {
            rb.useGravity = false;
            rb.mass = 1;
            rb.AddForce(Vector3.up * forceStrength);
            transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
        }

    }

}
