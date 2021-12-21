using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTercera : MonoBehaviour
{
    public Vector3 offset;
    public float sensibilidad;
    private Transform target;

    //nunca dejar el lerp a 0 o la camara no funcionara
    [Range (0, 1)]public float LerpValue;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, LerpValue);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
