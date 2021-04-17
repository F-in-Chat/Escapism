using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerWheel : MonoBehaviour
{
    public TMPro.TMP_Text first_power;

    public TMPro.TMP_Text second_power;

    public TMPro.TMP_Text third_power;
    // Start is called before the first frame update
    void Start()
    {
        first_power.text = "Telekinesis";
        second_power.text = "Freeze Time";
        third_power.text = "Bioluminescence";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
