using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int hp = 1;

    private Tilemap tilemap = null;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet)
        {
            TakeDamage(bullet.damage, collision);
        }
        Destroy(bullet.gameObject);
        //VFXSFX
    }

    public void TakeDamage(int damage, Collision2D collision)
    {
        if (tilemap == null)//if not a tile
        {
            hp -= damage;
            if (hp <= 0)
                Die();
        }
        else //if tile
        {
            Debug.Log("yep");
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Debug.Log(hit.point);
                hitPosition.x = hit.point.x - 0.1f;
                hitPosition.y = hit.point.y - 0.1f;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
           
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);
        //VFX
        //SFX
    }
}
