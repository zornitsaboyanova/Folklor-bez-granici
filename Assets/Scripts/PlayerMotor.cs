using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public bool canMove = true;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    public void ProcessMove(Vector2 input)
    {
        if (!canMove)
        {
            return;
        }

        Vector3 _moveDirection = Vector3.zero;
        _moveDirection.x = input.x;
        _moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(_moveDirection) * speed * Time.deltaTime);
    }
}
