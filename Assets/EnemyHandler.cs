using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //GameObject newenemy = Instantiate(pfbullet, rb.position, Quaternion.identity, transform);
    public GameObject Enemy1;
    public GameObject Boss1;
    public int enemiesAlive = 0;
    
    
    public bool allenemiesDead() {
        if(enemiesAlive>0)return false;
        else return true;
    }
    public void spawnEnemy1()
    {
        enemiesAlive++;
        GameObject newEnemy1 = Instantiate(Enemy1, transform.position, Quaternion.identity, transform);
        
    }

    public void spawnBoss1()
    {
        enemiesAlive++;
        GameObject newBoss1 = Instantiate(Boss1, transform.position, Quaternion.identity, transform);
        

    }

    
    public void enemyDied() {
        if (enemiesAlive > 0) enemiesAlive--;
        else print("error tried making enmies alive negative");
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
