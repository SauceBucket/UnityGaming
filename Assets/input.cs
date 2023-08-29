using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    
    public Collider2D PlayerCollider;
    [SerializeField] private float cooldowntime;
    private float _nextfiretime = 0;
    public bool iscoolingdown=> Time.time < _nextfiretime;
    public void startcooldown() => _nextfiretime = Time.time + cooldowntime;   
    public GameObject pfbullet;
    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update

   
    private void MovementCheck() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            rigidbody.velocity += Vector2.up * 0.5f;
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            rigidbody.velocity += Vector2.down * 0.5f;
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.velocity += Vector2.left * 0.5f;
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.velocity += Vector2.right * 0.5f;
            
        }
        return;
    }
     
    private void ShootingCheck() {

        if (Input.GetKey(KeyCode.Space) && !iscoolingdown)
        {
            GameObject newbullet = Instantiate(pfbullet, rigidbody.position, Quaternion.identity,transform);
            newbullet.tag = "PlayerBullet";
            startcooldown();
        }

        return;
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        ShootingCheck();
        

    }
}
