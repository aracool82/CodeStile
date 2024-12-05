using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
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
            var newBullet = Instantiate(_bulletPrefab, transform.position , Quaternion.identity);
            newBullet.Init((_target.position - transform.position).normalized);
            
            yield return _wait;
        }
    }
}