using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    public float force = 100;
    // Start is called before the first frame update
    //TODO: utilitzar addforce per configurar el moviment.
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = Vector3.forward * force * Time.deltaTime;
    }
}
