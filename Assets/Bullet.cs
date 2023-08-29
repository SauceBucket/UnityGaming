using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public Collider2D  BulletCollider;
    private void Start()
    {
        switch (gameObject.tag) {

            case "PlayerBullet":
                    this.gameObject.transform.position = GetComponentInParent<Rigidbody2D>().position + Vector2.up * 5;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 200;
                    break;
            case "EnemyBullet":
                    this.gameObject.transform.position = GetComponentInParent<Rigidbody2D>().position + Vector2.down * 5;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 50;
                    break;
            default:
                    break;
        }
    }

    private void Awake()
    {

        Destroy(gameObject, 5.0f);
        this.gameObject.GetComponent<Transform>().localScale = new Vector3(0.5f,0.5f, 0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }



}
