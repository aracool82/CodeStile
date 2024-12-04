using UnityEngine;

public class PointToPointMover : MonoBehaviour
{
    private float _speed = 10.0f;
    private Transform[] _childs;
    private int _currentIndex = 0;

    private void Start()
    {
        if(transform.childCount == 0)
            Debug.LogWarning($"<color=yellow> No children found </color>");
        
        _childs = new Transform[transform.childCount];

        for (int i = 0; i < _childs.Length; i++)
            _childs[i] = transform.GetChild(i).transform;
        
        transform.DetachChildren();
    }

    private void Update()
    {
        if(_childs.Length == 0 )
            return;
        
        var target = _childs[_currentIndex].position;
        var step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (transform.position == target)
        {
            _currentIndex = (_currentIndex + 1) % _childs.Length;
            transform.forward = _childs[_currentIndex].position - transform.position;
        }
    }
}