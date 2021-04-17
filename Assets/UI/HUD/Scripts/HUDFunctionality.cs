using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    public PowerWheel powerWheel;

    public bool test = false;

    private bool displayPowerWheel() {
        if (test) {
            powerWheel = new PowerWheel();
            return true;
        }
        return false;
    }

    private void openPowerWheel() {
        displayPowerWheel();
    }
    void Start()
    {
        // displayPowerWheel();
    }

    // Update is called once per frame
    void Update()
    {
        // test = true;
        // openPowerWheel();
    }
}
