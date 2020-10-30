using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public GameObject myPreFab;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Hero") == null){
            GameObject newGameObject =  Instantiate(myPreFab, transform.position, Quaternion.identity);


        }
    }
}
