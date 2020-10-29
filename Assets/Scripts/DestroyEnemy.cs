using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        // if(other.collider.GetComponent<PlayerController>() != null ) {
        //     Destroy(gameObject);
        // }

        string destroyerName = other.collider.gameObject.tag;

        if(destroyerName == "Hero" || destroyerName == "Obstruction"){
            Destroy(gameObject);
        }
    }
}
