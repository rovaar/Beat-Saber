using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    public GameObject slicerGO;
    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
    }
}
