﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        // if(other.collider.GetComponent<PlayerController>() != null ) {
        //     Destroy(gameObject);
        // }

        string destroyerName = other.collider.gameObject.tag;
        // bool killShot = other.contacts[0].normal.y < -0.5;
        bool killShot = true;

        if((destroyerName == "Hero" || destroyerName == "Obstruction") && killShot ){
            Destroy(gameObject);
            return;
        }
    }
}
