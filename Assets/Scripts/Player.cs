﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Rigidbody2D _playerRB;
    private LineRenderer _lineRenderer;    
    private float _timeSittingAround;    
    private bool _isLaunched;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _velocity = 300;

    private void Awake() {
        _playerRB = gameObject.GetComponent<Rigidbody2D>();

        _initialPosition = transform.position;
        
        _rigidbody =  _playerRB.GetComponent<Rigidbody2D>();
    }

    private void Update() {

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        float v = GetComponent<Rigidbody2D>().velocity.magnitude;

        if( _isLaunched && 
            v <= 0.1){
                _timeSittingAround += Time.deltaTime;
            }
            
        if( 
            transform.position.y > 7  || 
            transform.position.y < -4 ||
            transform.position.x < -25 || 
            transform.position.x > 20 ||
            _timeSittingAround > 1){

            // reset player
            transform.position = _initialPosition;
            _timeSittingAround = 0;
            _isLaunched = false;
            _playerRB.gravityScale = 0;
            GetComponent<LineRenderer>().enabled = true;
            _playerRB.GetComponent<Transform>().rotation = Quaternion.identity;
        }
    }

    private void OnMouseDrag() {

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPosition.x = Mathf.Clamp(newPosition.x, -19.0f, -13.0f );

        newPosition.y = Mathf.Clamp(newPosition.y, -4.0f, 4.0f);

        newPosition.z = 0;

        transform.position= newPosition;
    
    }

    private void OnMouseUp() {
        
        Vector2 direction = _initialPosition - transform.position;

        _playerRB.AddForce(direction * _velocity);
        
        _playerRB.gravityScale = 1;

        _isLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

}
