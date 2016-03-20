using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VelocityMagnitudeSlider : MonoBehaviour {

	Slider vSlider;
    void Awake()
    {
        vSlider = GetComponent<Slider>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vSlider.value = Mathf.MoveTowards(vSlider.value,RBFPS.S.rb.velocity.magnitude,Time.deltaTime*5.0f);
    }
}
