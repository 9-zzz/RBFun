using UnityEngine;
using System.Collections;

public class SimpleBulletPlayerDetectorTrigger : MonoBehaviour
{

    public bool playerIn = false;

   void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            playerIn = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            playerIn = false;
    }

}
