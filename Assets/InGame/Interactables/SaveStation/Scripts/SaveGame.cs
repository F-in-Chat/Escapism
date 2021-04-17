using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance;

    void awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Save()
    {
        
    }
}
