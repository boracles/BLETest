using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour
{
    private BLE bleMgr;
    
    public Light dirLight;
    
    void Start()
    {
        bleMgr = BLE.instance;
    }

    void Update()
    {
        switch (bleMgr.bluetoothOn)
        {
            case true:
            {
                float _intensity = 1-(float.Parse(bleMgr.message)/880);

                dirLight.intensity = _intensity*2.0f;
                break;
            }
        }
    }
}
