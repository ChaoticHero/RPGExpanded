using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        player.transform.position = new Vector2(9, 10);
    }
}
