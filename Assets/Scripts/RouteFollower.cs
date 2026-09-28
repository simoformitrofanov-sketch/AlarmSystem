using UnityEngine;

public class RouteFollower : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 1f;

    private int _currentIndex;

    private void Update()
    {
        if (_waypoints.Length == 0)
            return;

        Transform waypoint = _waypoints[_currentIndex];
        transform.position = Vector3.MoveTowards(
            transform.position, waypoint.position, _speed * Time.deltaTime);

        if (transform.position == waypoint.position)
            _currentIndex = (_currentIndex + 1) % _waypoints.Length;
    }
}