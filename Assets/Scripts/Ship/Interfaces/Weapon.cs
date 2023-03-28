using UnityEngine;

public interface IWeapon
{
    public void Shoot(GameObject prefab, Transform child);
}
public class WeaponBehaviour : IWeapon
{
    private Ship parent;
    private float reloadTime;
    private float damage;
    private float rotateSpeed;
    private float bulletSpeed;
    private float bulletLifeTime;

    public WeaponBehaviour(Ship parent, float reloadTime, float damage, float rotateSpeed, float bulletSpeed, float bulletLifeTime)
    {
        this.parent = parent;
        this.reloadTime = reloadTime;
        this.damage = damage;
        this.rotateSpeed = rotateSpeed;
        this.bulletSpeed = bulletSpeed;
        this.bulletLifeTime = bulletLifeTime;
    }
    public void Shoot(GameObject prefab, Transform child)
    {
        var obj = Object.Instantiate(prefab, child.transform.position, child.transform.rotation);
        var bullet = obj.GetComponent<Bullet>();
        bullet.Init(parent, bulletSpeed, damage, bulletLifeTime);
    }
}