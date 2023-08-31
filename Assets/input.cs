using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    
    public Collider2D PlayerCollider;
    [SerializeField] private float cooldowntime;
    private float _nextfiretime = 0;
    public bool iscoolingdown=> Time.time < _nextfiretime;
    public GameObject GameStateHandler;
    public void startcooldown() => _nextfiretime = Time.time + cooldowntime;   
    public GameObject pfbullet;
    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    public int lives = -1;
    private float respawn_timer =0;

   
    private void MovementCheck() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            rigidbody.velocity += Vector2.up * 1f;
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            rigidbody.velocity += Vector2.down * 1f;
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.velocity += Vector2.left * 1f;
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.velocity += Vector2.right * 1f;
            
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
        if (collision.gameObject.tag == "EnemyBullet" )
        {
            if (lives >= 0)
            {
                gameObject.transform.position = new Vector3(0f, -8000f, 0f);
                lives--;
                respawn_timer = Time.time;
            }
            else
            {
                
                GameStateHandler.GetComponent<HandleGameState>().PlayerLostStart(); 
                //gameObject.SetActive(false);
            }
        }
        

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn_timer != 0 ) {

            if (Time.time > respawn_timer + 2.5f)
            {
                respawn_timer = 0;
                gameObject.transform.position = new Vector3(0f, -80f, 0f);
            }
            else
            {
                return;
            }
        
        }

        MovementCheck();
        ShootingCheck();
        

    }
}
