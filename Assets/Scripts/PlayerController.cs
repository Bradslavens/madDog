using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector3 initialPosition;
    Rigidbody2D playerRB;
    LineRenderer lineRenderer;

    [SerializeField] float velocity;

    private void Awake() {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        
        initialPosition = transform.position;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void Update() {
        if(transform.position.y > 5  || transform.position.x < -19 || transform.position.x > 19){
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnMouseDrag() {

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPosition.z = 0;

        transform.position= newPosition;
    
    }

    private void OnMouseUp() {
        
        Vector2 direction = initialPosition - transform.position;

        playerRB.AddForce(direction * velocity);
        
        playerRB.gravityScale = 1;
    }
}
