using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter4 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        player.transform.position = new Vector2(11, -33);
    }
}
