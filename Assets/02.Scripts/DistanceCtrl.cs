using System;
using UnityEngine;
using UnityEngine.AI;

public class DistanceCtrl : MonoBehaviour
{
    private BLE bleMgr;
    private Camera cam;
    public Transform back;
    private NavMeshAgent navmeshAgent;
    [SerializeField] private float dist;

    private void Start()
    {
        bleMgr = BLE.instance;
        cam = Camera.main;
        navmeshAgent = GetComponent<NavMeshAgent>();
        
        navmeshAgent.isStopped = true;
    }

    private void Update()
    {
        dist = Vector3.Distance(cam.transform.position, transform.position);
        
        Debug.Log($"거리 {dist}");

        if (!bleMgr.bluetoothOn) return;
        float _dist = float.Parse(bleMgr.message);
                
                
        if (_dist > dist && Math.Abs(_dist - dist) >= 0.1f)
        {
            navmeshAgent.SetDestination(back.position);
            navmeshAgent.isStopped = false;
        }
        else if(Math.Abs(_dist - dist) < 0.1f)
        {
            navmeshAgent.isStopped = true;
        }
        else
        {
            navmeshAgent.SetDestination(cam.transform.position);
            navmeshAgent.isStopped = false;
        }

    }
}
