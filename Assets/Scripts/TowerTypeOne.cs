using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeOne : MonoBehaviour
{
    public float damage;
    public float firerate;
    public float range;
    public GameObject projectile;

    private float cooldown;
    
    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
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
        if(enemyArray.Length == 0)
        {
            return;
        }
        Debug.LogError("aaa: " + enemyArray[0]);

        EnemyRanger[] rangerScriptReferenceArray = new EnemyRanger[enemyArray.Length];
        for(int i = 0; i < enemyArray.Length; i++)
        {
            rangerScriptReferenceArray[i] = (EnemyRanger)enemyArray[i].GetComponent(typeof(EnemyRanger));
        }

        List<GameObject> enemiesInRange = null;
        List<EnemyRanger> inRangeScripts = null;
        for(int i = 0; i < enemyArray.Length; i++)
        {
            if(Vector2.Distance(transform.position, rangerScriptReferenceArray[i].GetPosition()) <= range)
            {
                enemiesInRange.Add(enemyArray[i]);
                inRangeScripts.Add(rangerScriptReferenceArray[i]);
            }
        }
        if(enemiesInRange.Count != 0)
        {
            List<GameObject> furthestEnemies = null;
            List<EnemyRanger> furthestScripts = null;

            int furthestWaypoint = 0;
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (rangerScriptReferenceArray[i].GetWaypointIndex() > furthestWaypoint)
                {
                    furthestWaypoint = rangerScriptReferenceArray[i].GetWaypointIndex();
                }
            }
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (rangerScriptReferenceArray[i].GetWaypointIndex() >= furthestWaypoint)
                {
                    furthestEnemies.Add(enemiesInRange[i]);
                    furthestScripts.Add(rangerScriptReferenceArray[i]);
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
        GameObject proj = (GameObject)Instantiate(projectile, transform);
        ProjectileScript projScript = (ProjectileScript)proj.GetComponent(typeof(ProjectileScript));
        projScript.SetTarget(targetEnemy);

        cooldown = firerate / 60.0f;
    }
}
