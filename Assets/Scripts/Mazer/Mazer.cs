using UnityEngine;
using UnityEngine.AI;

public class Mazer : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentMoveTargetPosition;
    [SerializeField] private Vector2 _movingArea;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetNewMovePosition();
    }

    private void Update()
    {
        if(transform.position == _navMeshAgent.pathEndPosition)
        {
            SetNewMovePosition();
        }
    }

    private void SetNewMovePosition()
    {
        _currentMoveTargetPosition = new Vector3(Random.Range(-_movingArea.x, _movingArea.x), 0, Random.Range(-_movingArea.y, _movingArea.y));

        _navMeshAgent.SetDestination(_currentMoveTargetPosition);
    }
}
