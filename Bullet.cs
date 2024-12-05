using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
        _rigidbody.transform.up = direction; 
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}