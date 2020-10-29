using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject target;
    public Sprite projectileSprite;
    public float speed;
    public float damage;

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.transform.position - transform.position;
        dir = dir.normalized;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.transform.position) <= 0.04f)
        {
            //Damage enemy
            EnemyRanger enemyScript = (EnemyRanger)target.GetComponent(typeof(EnemyRanger));
            enemyScript.GetDamaged(damage);
            Destroy(gameObject);
        }
    }
}
