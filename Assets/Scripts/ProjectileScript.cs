using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Sprite projectileSprite;
    public float speed;
    public float damage;
    public float hitboxSize;
    public int pierces;
    public float slowPercent;
    public float rotateAdjustment;
    public char type;

    private GameObject target;
    private Vector2 dir;
    private List<GameObject> hitEnemies = new List<GameObject>();


    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

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
    
    public void SetRotation(Quaternion newRotation)
    {
        transform.rotation = newRotation;
    }

    public void Target()
    {
        switch (type)
        {
            case 'C':
                SoundManagerScript.PlaySound("candyCorn");
                break;
            case 'S':
                SoundManagerScript.PlaySound("pixyStix");
                break;
            case 'G':
                SoundManagerScript.PlaySound("gumball");
                break;
            case 'P':
                SoundManagerScript.PlaySound("pez");
                break;
            default:
                break;
        }
        dir = target.transform.position - transform.position;
        dir = dir.normalized;

        Vector3 arrow = target.transform.position - transform.position;
        float angle = Mathf.Atan2(arrow.y, arrow.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotateAdjustment));
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

        if(nearestEnemy != null && shortestDistance < hitboxSize && hitEnemies.Contains(nearestEnemy) == false)
        {
            EnemyScript enemyScript = (EnemyScript)nearestEnemy.GetComponent(typeof(EnemyScript));
            hitEnemies.Add(nearestEnemy);
            enemyScript.GetSlowed(slowPercent);
            enemyScript.GetDamaged(damage);
            pierces--;
            if(pierces < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
