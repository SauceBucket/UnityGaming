


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;


public class Boss1Logic : MonoBehaviour
{
    public Collider2D Collider;
    public GameObject pfbullet;
    public GameObject HealthBar;
    float startingxvalue;
    public GameObject scalingobject;
    GameObject healthbarobj;

    [SerializeField] private float cooldowntime;
    private float _nextfiretime = 2;
    public bool iscoolingdown => Time.time < _nextfiretime;
    public void startcooldown() => _nextfiretime = Time.time + cooldowntime;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0f, -90f, 0f);
        healthbarobj = Instantiate(HealthBar, pos , Quaternion.identity);
        healthbarobj.GetComponent<HealthBarLogic>().sethealth(100);
        transform.position = pos * -1;
    }
    public void MovementLogic()
    {

        

    }
    public void OnDestroy()
    {
        transform.parent.GetComponentInParent<EnemyHandler>().enemyDied();
    }

    public void OnEnable()
    {
        
    }
    public void ShootingLogic()
    {

        if (!iscoolingdown)
        {
            GameObject newbullet = Instantiate(pfbullet, transform.position, Quaternion.identity, transform);
            newbullet.tag = "EnemyBullet";
            startcooldown();
        }

    }
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            --healthbarobj.GetComponent<HealthBarLogic>().healthtotal;
            if (healthbarobj.GetComponent<HealthBarLogic>().healthtotal <= 0) {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        MovementLogic();
        ShootingLogic();
        //DieLogic();
    }
}
