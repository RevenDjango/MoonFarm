using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public bool IsPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteraccion")
        {

            other.GetComponentInParent<PickUp>().ObjectToPickUp = this.gameObject;

        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "PlayerInteraccion")
        {

            other.GetComponentInParent<PickUp>().ObjectToPickUp = null;

        }

    }
}
