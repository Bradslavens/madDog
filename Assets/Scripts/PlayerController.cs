using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector3 _initialPosition;
    Rigidbody2D _playerRB;
    LineRenderer _lineRenderer;

    [SerializeField] float velocity;

    private void Awake() {
        _playerRB = gameObject.GetComponent<Rigidbody2D>();

        _initialPosition = transform.position;
        _lineRenderer = gameObject.GetComponent<_LineRenderer>();
    }

    private void Update() {
        if( transform.position.y > 5  || 
            transform.position.x < -19 || 
            transform.position.x > 19){

            ReloadScene();
        }
    }

    private void OnMouseDrag() {

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPosition.z = 0;

        transform.position= newPosition;
    
    }

    private void OnMouseUp() {
        
        Vector2 direction = _initialPosition - transform.position;

        _playerRB.AddForce(direction * velocity);
        
        _playerRB.gravityScale = 1;
    }

    private void ReloadScene(){
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
