using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    private float x,y,z;

    public Rigidbody rb;
    public float fuerzaDeSalto = 2f;
    public bool puedoSaltar;
    public bool tocandosuelo;
  


    
   // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = true;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    void FixedUpdate() {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, z * Time.deltaTime * velocidadMovimiento);
    }

    void  Update()
    {  

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        anim.SetFloat("VelX",  x);
        anim.SetFloat("VelY",  z);

        if(puedoSaltar){
                if(Input.GetKeyDown(KeyCode.Space)){
                    puedoSaltar=false;
                    anim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0,fuerzaDeSalto,0), ForceMode.Impulse);
                }
                anim.SetBool("tocoSuelo", true);
        }else{
            EstoyCayendo();
        }
    } 
    public void EstoyCayendo(){
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Terreno"))
            {
                puedoSaltar=true;
                tocandosuelo = true;               
            }
    }
}

