using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController Player;
    public float velocidad;

    public float gravedad = 1.7f;
    public float caida;
    public float salto;

    private Vector3 movPlayer;
    private Vector3 PlayerInput;

    public Camera mainCamera;
    private Vector3 camDelante;
    private Vector3 camDerecha;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {   
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        PlayerInput = new Vector3(horizontalMove, 0, verticalMove);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);

        camDirection();

        movPlayer = PlayerInput.x * camDerecha + PlayerInput.z * camDelante;

        Player.transform.LookAt(Player.transform.position + movPlayer);

        movPlayer = movPlayer * velocidad;

        SetGravedad();

        Habilidades();

        Player.Move(movPlayer * Time.deltaTime);

    }

    void camDirection()
    {

        camDelante = mainCamera.transform.forward;
        camDerecha = mainCamera.transform.right;

        camDelante.y = 0;
        camDerecha.y = 0;

        camDelante = camDelante.normalized;
        camDerecha = camDerecha.normalized;
    }

    //fincion para los movimientos del personaje
    void Habilidades()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump"))
        {

            caida = salto;
            movPlayer.y = caida;

        }
    }
    void SetGravedad()
    {

        if (Player.isGrounded)
        {
            caida = -gravedad * Time.deltaTime;
            movPlayer.y = caida;
        }

        else
        {
            caida -= gravedad * Time.deltaTime;
            movPlayer.y = caida;
        }
    }
}