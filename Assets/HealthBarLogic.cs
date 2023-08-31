using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class HealthBarLogic : MonoBehaviour
{

    public float healthtotal = 100f;

    private float health_max = 100f;

    UnityEngine.Vector3 tranformscaleorig;


    public void sethealth(float healthtoset) { 
            
        healthtotal = healthtoset;
        health_max = healthtoset;
    
    }
    
    


    // Start is called before the first frame update
    void Start()
    {
        if (healthtotal == 1f)
            healthtotal = 100;
         tranformscaleorig = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 change = transform.localScale;
        change.x = (tranformscaleorig.x * (System.Math.Abs(healthtotal/health_max)));
        transform.localScale = change;

    }
}
