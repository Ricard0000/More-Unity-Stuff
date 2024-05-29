using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorCamera : MonoBehaviour
{

    public float sensitivity;
    public float slowSpeed, normalSpeed, fastSpeed;
    float currentSpeed;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Rotation();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Movement();

        void Rotation()
        {
            Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
            transform.Rotate(mouseInput * sensitivity * Time.deltaTime * 50);
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }

        void Movement()
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = fastSpeed;
            }
            else if(Input.GetKey(KeyCode.LeftAlt))
            {
                currentSpeed = slowSpeed;
            }
            else
            {
                currentSpeed = normalSpeed;
            }
            transform.Translate(input * currentSpeed * Time.deltaTime);
        }




    }
}
