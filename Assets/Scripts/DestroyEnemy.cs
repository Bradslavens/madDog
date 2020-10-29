using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Link"){
            Destroy(this.gameObject);
        }
    }
}
