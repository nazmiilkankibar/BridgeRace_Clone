using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private MovementJoystick joystick;
    private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private float inputX;
    private float inputZ;

    private void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MovementJoystick>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        inputX = joystick.joystickVector.x;
        inputZ = joystick.joystickVector.y;

        Vector3 movement = new Vector3(inputX, 0, inputZ);
        float magnitude = Mathf.Clamp01(movement.magnitude) * speed;
        movement.Normalize();
        transform.Translate(movement * magnitude * Time.deltaTime, Space.World);
        //transform.position += movement * magnitude * Time.deltaTime;
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);

            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
