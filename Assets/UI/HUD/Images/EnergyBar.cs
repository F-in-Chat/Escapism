using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_Text energy_label;

    public TMPro.TMP_Text energy_number;

    public int energy_count;
    void Start()
    {
        energy_label.text = "Energy";
        energy_count = 100;
        energy_number.text = energy_count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
