using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 initialPosition;
    Rigidbody2D playerRB;

    [SerializeField] float velocity;

    private void Awake() {
        initialPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
