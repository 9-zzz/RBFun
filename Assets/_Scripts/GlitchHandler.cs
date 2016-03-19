using UnityEngine;
using System.Collections;

public class GlitchHandler : MonoBehaviour {

    public static GlitchHandler S;
    public float cd = 0.0f;
    public float cdSpeed = 8.0f;
    public float slj = 0.0f;
    public float sljSpeed = 8.0f;
    public float vj = 0.0f;
    public float vjSpeed = 8.0f;
    public float hs= 0.0f;
    public float hsSpeed = 0.1f;
    public float dgi = 0.0f;
    public float dgiSpeed = 0.1f;

    void Awake()
    {
        S = this;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Kino.AnalogGlitch>().colorDrift = cd;
        GetComponent<Kino.AnalogGlitch>().scanLineJitter = slj;
        GetComponent<Kino.AnalogGlitch>().verticalJump = vj;
        GetComponent<Kino.AnalogGlitch>().horizontalShake = hs;
        GetComponent<Kino.DigitalGlitch>().intensity = dgi;

        if (RBFPS.S.rb.velocity.magnitude >= 48)
            cd = Mathf.MoveTowards(cd, 0.05f, Time.deltaTime * cdSpeed);

        if (RBFPS.S.jetPackFuel <= 10.0f)
        {
            cd = Mathf.MoveTowards(cd, 0.25f, Time.deltaTime * cdSpeed);
            slj = Mathf.MoveTowards(slj, 0.35f, Time.deltaTime * sljSpeed);
            vj = Mathf.MoveTowards(vj, 0.01f, Time.deltaTime * vjSpeed);
            hs = Mathf.MoveTowards(hs, 0.01f, Time.deltaTime * hsSpeed);
            dgi = Mathf.MoveTowards(dgi, 0.02f, Time.deltaTime * dgiSpeed);
        }
        else if(!(RBFPS.S.rb.velocity.magnitude >= 48))
        {
            cd = Mathf.MoveTowards(cd, 0.0f, Time.deltaTime * cdSpeed);
            slj = Mathf.MoveTowards(slj, 0.0f, Time.deltaTime * sljSpeed);
            vj = Mathf.MoveTowards(vj, 0.0f, Time.deltaTime * vjSpeed);
            hs = Mathf.MoveTowards(hs, 0.0f, Time.deltaTime * hsSpeed);
            dgi = Mathf.MoveTowards(dgi, 0.0f, Time.deltaTime * dgiSpeed);
        }
    }
}
