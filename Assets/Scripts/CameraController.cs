using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f; 
    public float rotationSpeed = 10f; 

    private Vector3 initialPosition; 
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(transform.position, transform.right, -rotationY);
            transform.RotateAround(transform.position, Vector3.up, rotationX);
        }

        float moveX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0f, moveZ));

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
