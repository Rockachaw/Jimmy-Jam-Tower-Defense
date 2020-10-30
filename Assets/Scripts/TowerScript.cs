using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float damage;
    public float firerate;
    public float range;
    public GameObject projectile;
    public float yAdjustment;
    
    //0 - No turning of tower. 1 - Tower flips to fire left or right. 2 - Tower points towards enemy (uses rotateAdjustment).
    public int aimType;
    public float rotateAdjustment;

    private float totalCost;
    private int level = 1;

    private float cooldown;

    void Start()
    {
        gameObject.transform.Translate(new Vector3(0.0f, yAdjustment, 0f));
        cooldown = 0;
        GameObject rcReference = GameObject.Find("RangeCircle");
        RangeCircle rcScript = (RangeCircle)rcReference.GetComponent(typeof(RangeCircle));
        rcScript.MoveRangeCircle(transform.position.x, transform.position.y, range);
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            FindTarget();
        }
        cooldown -= Time.deltaTime;
    }

    void FindTarget()
    {
        //Find the enemy within the tower's range which is furthest along the path
        GameObject targetEnemy = null;

        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyArray.Length == 0)
        {
            return;
        }

        EnemyScript[] scriptReferenceArray = new EnemyScript[enemyArray.Length];
        for (int i = 0; i < enemyArray.Length; i++)
        {
            scriptReferenceArray[i] = (EnemyScript)enemyArray[i].GetComponent(typeof(EnemyScript));
        }

        List<GameObject> enemiesInRange = new List<GameObject>();
        List<EnemyScript> inRangeScripts = new List<EnemyScript>();
        for (int i = 0; i < enemyArray.Length; i++)
        {
            if (Vector2.Distance(transform.position, scriptReferenceArray[i].GetPosition()) <= range)
            {
                enemiesInRange.Add(enemyArray[i]);
                inRangeScripts.Add(scriptReferenceArray[i]);
            }
        }
        if (enemiesInRange.Count != 0)
        {
            List<GameObject> furthestEnemies = new List<GameObject>();
            List<EnemyScript> furthestScripts = new List<EnemyScript>();

            int furthestWaypoint = 0;
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (scriptReferenceArray[i].GetWaypointIndex() > furthestWaypoint)
                {
                    furthestWaypoint = scriptReferenceArray[i].GetWaypointIndex();
                }
            }
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (scriptReferenceArray[i].GetWaypointIndex() >= furthestWaypoint)
                {
                    furthestEnemies.Add(enemiesInRange[i]);
                    furthestScripts.Add(scriptReferenceArray[i]);
                }
            }

            float minDistance = float.MaxValue;
            for (int i = 0; i < furthestEnemies.Count; i++)
            {
                if (furthestScripts[i].GetDistanceToNextWaypoint() < minDistance)
                {
                    minDistance = furthestScripts[i].GetDistanceToNextWaypoint();
                    targetEnemy = furthestEnemies[i];
                }
            }
        }

        Attack(targetEnemy);
    }

    private void Attack(GameObject targetEnemy)
    {
        //Make an attack object based on the projectile prefab that was passed as a public parameter
        //Projectile prefab should take over once it has a target

        if(targetEnemy == null)
        {
            return;
        }

        if(aimType == 0)
        {
            //Do nothing
        }
        else if(aimType == 1)
        {
            //Flip to face enemy
            SpriteRenderer spriteRend = (SpriteRenderer)gameObject.GetComponent<SpriteRenderer>();
            if (targetEnemy.transform.position.x > gameObject.transform.position.x)
            {
                spriteRend.flipX = false;
            }
            else
            {
                spriteRend.flipX = true;
            }
        }
        else if(aimType == 2)
        {
            //Point at enemy
            Vector3 arrow = targetEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(arrow.y, arrow.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotateAdjustment));
        }

        GameObject proj = (GameObject)Instantiate(projectile, transform);
        ProjectileScript projScript = (ProjectileScript)proj.GetComponent(typeof(ProjectileScript));
        projScript.SetDamage(damage);
        projScript.SetTarget(targetEnemy);
        projScript.SetPosition(transform.position);
        projScript.SetRotation(transform.rotation);
        projScript.Target();

        cooldown = firerate / 60.0f;
    }

    public void OnMouseDown()
    {
        GameObject rcReference = GameObject.Find("RangeCircle");
        RangeCircle rcScript = (RangeCircle)rcReference.GetComponent(typeof(RangeCircle));
        rcScript.MoveRangeCircle(transform.position.x, transform.position.y, range);
    }

    public void AddCost(float addCost)
    {
        totalCost += addCost;
    }
    public float GetTotalCost()
    {
        return totalCost;
    }
    public int GetLevel()
    {
        return level;
    }
    public void LevelUp()
    {
        if (level == 1)
        {
            //Increase damage by 50%
            damage += damage * 0.5f;
        }
        else if (level == 2)
        {
            //Increase range by 50%
            range += range * 0.5f;
        }
        else if (level == 3)
        {
            //Increase firerate by 50%
            // * Remember that firerate is faster the lower it is.
            firerate = firerate / 2f;
        }
        level++;
    }
}
