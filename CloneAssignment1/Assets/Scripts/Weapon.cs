using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;
    public enum WeaponType {Melee, Bullet}
    public WeaponType weaponType; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemy = collision.GetComponent<EnemyScript>(); 
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            if (weaponType == WeaponType.Bullet)
            {
                Destroy(gameObject); 
            }
        }
    }
}
