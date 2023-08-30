


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Boss1Logic : MonoBehaviour
{
    public Collider2D Collider;
    public GameObject pfbullet;
    public Rigidbody2D rb;
    public Healthbar healthbar;
    public GameObject PlayerObject;
    float startingxvalue;

    [SerializeField] private float cooldowntime;
    private float _nextfiretime = 2;
    public bool iscoolingdown => Time.time < _nextfiretime;
    public void startcooldown() => _nextfiretime = Time.time + cooldowntime;

    // Start is called before the first frame update
    void Start()
    {
        startingxvalue = Random.Range(-1f, 1f);
        transform.position = new Vector3(startingxvalue * 100f, 80f, 0f);
        rb.position = transform.position;
        rb.velocity = Vector2.down * 10 + Vector2.left * Random.value * 5 + Vector2.right * Random.value * 5;
    }
    public void MovementLogic()
    {

        

    }
    public void OnDestroy()
    {
        GetComponentInParent<EnemyHandler>().enemyDied();
    }
    public void ShootingLogic()
    {

        if (!iscoolingdown)
        {
            GameObject newbullet = Instantiate(pfbullet, rb.position, Quaternion.identity, transform);
            newbullet.tag = "EnemyBullet";
            startcooldown();
        }

    }
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            --healthbar;
            if (healthbar <= 0) {
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
