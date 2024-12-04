using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _delay = 2f;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position , Quaternion.identity);
            newBullet.Rigidbody.transform.up = direction;
            newBullet.Rigidbody.velocity = direction * _speed;
            
            yield return _wait;
        }
    }
}