using UnityEngine;

public class PointToPointMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Vector3[] _points;
    
    private int _currentIndex = 0;

    private void Start()
    {
        _points = new Vector3[transform.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = transform.GetChild(i).position;
    }

    private void Update()
    {
        var target = _points[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (transform.position == target)
            _currentIndex = (_currentIndex + 1) % _points.Length;
    }
}