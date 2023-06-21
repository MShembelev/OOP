using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeContoller : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.S))
        {
            Vector2 underBridge = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
            collision.collider.gameObject.transform.position = underBridge;
        }
    }
}
