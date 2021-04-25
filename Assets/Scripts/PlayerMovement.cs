using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = 50;

    [Header("Colliders of Cranes")]
    [SerializeField] private SphereCollider _craneRight;
    [SerializeField] private SphereCollider _craneLeft;


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        move.y -= _gravity * Time.deltaTime;
        _controller.Move(move *_speed * Time.deltaTime);
    }

    // Позволяем крутить только если подошли в упор к кранам
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crane")
        {
            _craneRight.enabled = true;
            _craneLeft.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Crane")
        {
            _craneRight.enabled = false;
            _craneLeft.enabled = false;
        }
    }
}
