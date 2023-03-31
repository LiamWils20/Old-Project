using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Vector2 turn;
    public float sensitivity = 0.5f;
    public Vector2 deltaMove;
    public float speed = 1;
    public GameObject mover;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") + sensitivity;
        turn.y += Input.GetAxis("Mouse Y") + sensitivity;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
    }

    internal Vector3 ViewportToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
