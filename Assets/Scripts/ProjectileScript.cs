using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Sprite projectileSprite;
    public float speed;
    public float damage;
    public float hitboxSize;

    private GameObject target;
    private Vector2 dir;

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void Target()
    {
        dir = target.transform.position - transform.position;
        dir = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }

        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance < hitboxSize)
        {
            EnemyScript enemyScript = (EnemyScript)nearestEnemy.GetComponent(typeof(EnemyScript));
            enemyScript.GetDamaged(damage);
            Destroy(gameObject);
        }
    }
}
