using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JetPackSlider : MonoBehaviour
{

    Slider tSlider;
    void Awake()
    {
        tSlider = GetComponent<Slider>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tSlider.value = RBFPS.S.jetPackFuel;
    }

}
