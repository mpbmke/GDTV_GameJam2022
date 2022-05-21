using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _speedMultiplier = 1.5f;

    bool _speedBoost;

    Vector3 _moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        if (Input.GetButtonDown("Run"))
            _speedBoost = true;

        if (Input.GetButtonUp("Run"))
            _speedBoost = false;

        var horizontalInput = Input.GetAxis("Horizontal");
        var forwardInput = Input.GetAxis("Vertical");

        if (!_speedBoost)
            _moveDirection = new Vector3(horizontalInput, 0, forwardInput) * _speed * Time.deltaTime;

        if (_speedBoost)
            _moveDirection = new Vector3(horizontalInput, 0, forwardInput) * _speed * _speedMultiplier * Time.deltaTime;

        transform.Translate(_moveDirection);
    }
}
