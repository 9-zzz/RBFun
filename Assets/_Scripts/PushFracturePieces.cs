using UnityEngine;
using System.Collections;

public class PushFracturePieces : MonoBehaviour
{
    public float pForce = 8.0f;
    public float deathTime = 4.0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, deathTime);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody>().AddForce(pForce * (transform.GetChild(i).transform.position - transform.position), ForceMode.Impulse);
            Destroy(transform.GetChild(i).gameObject, deathTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
