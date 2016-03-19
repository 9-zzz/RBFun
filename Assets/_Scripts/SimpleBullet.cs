using UnityEngine;
using System.Collections;

public class SimpleBullet : MonoBehaviour
{
    Rigidbody rb;
    Renderer rend;
    public float forwardForce;
    public float expldForce;
    public GameObject sbFrac;

    public Material toLerp;
    public bool hit = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        rb.velocity = RBFPS.S.rb.velocity;
        rb.AddRelativeForce(0, 0, forwardForce, ForceMode.Impulse);
        transform.rotation = Random.rotation;
    }

    void Update()
    {
        if(hit)
        {
            float lerp = Time.deltaTime * 1.0f;
            rend.material.Lerp(rend.material, toLerp, lerp);
        }
    }

    void ExplodeMake()
    {
        Instantiate(sbFrac, transform.position, transform.rotation);

        if (transform.GetChild(0).GetComponent<SimpleBulletPlayerDetectorTrigger>().playerIn)
        {
            //RBFPS.S.rb.AddForce(expldForce *(transform.position - RBFPS.S.transform.position), ForceMode.Impulse);
            RBFPS.S.rb.AddForce(0, expldForce, 0, ForceMode.Impulse);
            Camera.main.GetComponent<Kino.DigitalGlitch>().intensity = 1;
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        hit = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        Invoke("ExplodeMake", 1);
        GetComponent<SphereCollider>().enabled = false;
    }

}
