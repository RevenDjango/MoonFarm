﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform InteractionZone;



    void Update()
    {

        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<Pickable>().IsPickable == true && PickedObject == null)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<Pickable>().IsPickable = false;
                PickedObject.transform.SetParent(InteractionZone);
                PickedObject.transform.position = InteractionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;

            }

        }

        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                PickedObject.GetComponent<Pickable>().IsPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;



            }
        }
    }
}
