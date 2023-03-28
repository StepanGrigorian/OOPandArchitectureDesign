using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float damage;
    private Ship parent;
    private float lifeTime;
    private void Start()
    {
        StartCoroutine(DestroyAfter(lifeTime));
    }
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
    public void Init(Ship parent, float speed, float damage, float lifeTime)
    {
        this.parent = parent;
        this.speed = speed;
        this.damage = damage;
        this.lifeTime = lifeTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Ship ship = other.GetComponentInParent<Ship>();
            if (ship != parent)
            {
                ship.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}