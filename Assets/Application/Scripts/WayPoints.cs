using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance;
    [Header("WayPoint")]
    public List<Transform> waypoints;
    [SerializeField] private int _max_waypoint;

    [SerializeField] private GameObject _points;
    [SerializeField] private float xRange = 10.0f;
    [SerializeField] private float zRange = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        StartTrack();
    }


    public void StartTrack()
    {
        foreach (Transform _points in waypoints)
        {
            Destroy(_points.gameObject);
        }

        waypoints.Clear();

        for (int i = 0; i <= _max_waypoint; i++)
        {
            CreateWaypoints();
        }
    }

    void CreateWaypoints()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-xRange, xRange),
            0,
            Random.Range(-zRange, zRange)
        );

        GameObject _waypoint = Instantiate(_points, randomPosition, Quaternion.identity);
        waypoints.Add(_waypoint.transform);
    }


}
