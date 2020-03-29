using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodColliderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(0, 0, 0);
            transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(-170, 170), transform.position.y + UnityEngine.Random.Range(-80, 80), transform.position.z);
        }
    }
}
