using UnityEngine;
using System.Collections;

public class CubeGunSpawnPoint : MonoBehaviour
{
    public GameObject simpleBullet;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(simpleBullet, transform.position, transform.rotation);
        }
    }

}
