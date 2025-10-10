using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCBase : MonoBehaviour
{

    public Transform _targetMachine;
    public Transform _targetWaitPoint;
    public float _updateSpeed = 0.1f;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(GoToMachine());
    }
    private IEnumerator GoToMachine()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);

        _agent.SetDestination(_targetMachine.transform.position);
        yield return wait;
        StartCoroutine(GoToWaitPoint());
    }

    private IEnumerator GoToWaitPoint()
    {
        _agent.SetDestination(_targetWaitPoint.transform.position);
        yield return new WaitForSeconds(5f);
        StartCoroutine(GoToMachine());
    }

}
