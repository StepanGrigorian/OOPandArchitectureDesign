using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModule : Module
{
    private void Start()
    {
        SetWeaponBehaviour(new WeaponBehaviour());
    }
    [SerializeField] private float reloadTime;
    [SerializeField] private float damage;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    public bool CanShoot { get; private set; } = true;

    public delegate void Reloaded();
    public event Reloaded OnReloaded;

    public GameObject BulletPrefab;
    public Transform Child;

    private Ship target;

    public void SetTarget(Ship target)
    {
        this.target = target;
        StartCoroutine(LookAtTarget());
    }
    IEnumerator LookAtTarget()
    {
        var dir = Camera.main.WorldToScreenPoint(target.transform.position) - 
            Camera.main.WorldToScreenPoint(Child.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion LookAt = Quaternion.AngleAxis(angle, Vector3.forward);
        while (Child.rotation != LookAt)
        {
            Child.rotation = Quaternion.RotateTowards(
                Child.rotation, LookAt, rotateSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Shoot();
        OnReloaded += Shoot;
    }
    public void Shoot()
    {
        if (CanShoot)
        {
            var obj = Instantiate(BulletPrefab, 
                Child.transform.position, Child.transform.rotation);
            var bullet = obj.GetComponent<Bullet>();
            bullet.Init(Parent, bulletSpeed, damage, bulletLifeTime);
            CanShoot = false;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        float time = 0;
        while (time < reloadTime * Parent.ReloadMultiplier)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        CanShoot = true;
        OnReloaded?.Invoke();
    }
    private void OnMouseDown()
    {
        Slot.used = false;
        Parent.Weapons.Remove(this);
        Destroy(gameObject);
    }
}