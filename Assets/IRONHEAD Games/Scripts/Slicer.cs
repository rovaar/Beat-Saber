﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.SceneManagement;

public class Slicer : MonoBehaviour
{
    public Material MaterialAfterSlice;
    public LayerMask sliceMask;
    public GameObject slice;
    public AudioClip swordSound;
    public bool isTouched;
    private GameObject sceneManager;
    private ScoreManager scoreManager;
    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("scoreManager");
        scoreManager = sceneManager.GetComponent<ScoreManager>();
    }
    private void Update()
    {     
        if (isTouched == true)
        {
            isTouched = false;
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
              
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, MaterialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, MaterialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, MaterialAfterSlice);

             
                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
               

                MakeItPhysical(upperHullGameobject, objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity);
                MakeItPhysical(lowerHullGameobject, objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity);
                AudioSource.PlayClipAtPoint(swordSound, objectToBeSliced.transform.position);
                scoreManager.AddScore(1);
                Destroy(objectToBeSliced.gameObject);
            }
        }

    }
    private void MakeItPhysical(GameObject obj, Vector3 _velocity)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().velocity = -_velocity;

        int randomNumberX = Random.Range(0,2);
        int randomNumberY = Random.Range(0, 2);
        int randomNumberZ = Random.Range(0, 2);

        obj.GetComponent<Rigidbody>().AddForce(3*new Vector3(randomNumberX,randomNumberY,randomNumberZ),ForceMode.Impulse);       
        obj.AddComponent<DestroyAfterSeconds>();

    }

   

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

}