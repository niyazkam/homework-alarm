using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _initialLocation;
    [SerializeField] private Vector3 _theftLocation;
    [SerializeField] private float _speed;
    [SerializeField] private int secondsToTheft;

    private Vector3 _targetPosition;
    private float _distanceThreshold = 0.01f;
    private bool _isMoving;

    private void Start()
    {
        transform.position = _initialLocation;
        _targetPosition = _theftLocation;
        _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _targetPosition) < _distanceThreshold)
            {
                _isMoving = false;

                if (_targetPosition == _theftLocation)
                    StartCoroutine(CommitTheft());
            }
        }
    }

    private IEnumerator CommitTheft()
    {
        yield return new WaitForSeconds(secondsToTheft);

        _targetPosition = _initialLocation;
        _isMoving = true;
    }
}
