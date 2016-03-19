using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RBFPS_UI : MonoBehaviour
{
    Text tText;

    void Awake()
    {
        tText = this.GetComponent<Text>();
    }

    void Start()
    {

    }

    void Update()
    {
        tText.text = "VELOCITY: " + RBFPS.S.rb.velocity +
            "\n\nV-MAG : " + RBFPS.S.rb.velocity.magnitude +
            "\n\nH : " + RBFPS.S.offsetDistance;

    }

}
