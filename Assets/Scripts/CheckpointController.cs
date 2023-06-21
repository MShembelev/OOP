using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            col.gameObject.GetComponent<HeroController>().SetCheckpoint(col.gameObject.transform.position);
        }
    }
}
