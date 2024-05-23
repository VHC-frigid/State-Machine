using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 input;
    private bool isGrounded;

    public Camera camera;
    public float speed = 5f;
    public LayerMask groundMask;

    [SerializeField] private Animator anim;
    
    private void Start()
    {
        
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
        if (anim == null)
        {
            Debug.Log("don't forget to set animator for your player");
        }
        
        rb = GetComponent<Rigidbody>();

        if (camera == null)
        {
            camera = Camera.main;
        }
    }
    
    void Update()
    {

        input = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));

        if (input.magnitude > 1)
        {
            input.Normalize();
        }

        if (input.magnitude > 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //Relational Movement
        float inputMag = input.magnitude;
        input = camera.transform.TransformDirection(input);
        input.y = 0f;
        input.Normalize();
        input *= inputMag;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
        }

        //rotate towards input direction
        if(input.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(input);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

    }

    private void FixedUpdate()
    {
        //transform.position += input * speed * Time.deltaTime;
        rb.MovePosition(transform.position + input * speed * Time.deltaTime);

        isGrounded = Physics.Raycast(transform.position, -transform.up, 1.05f,groundMask);

        //Debug.DrawLine(transform.position, -transform.up * 1.05f, Color.magenta);
    }

}
