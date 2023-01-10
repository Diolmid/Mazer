using UnityEngine;
using UnityEngine.AI;

public class WalkingEnemy : MonoBehaviour
{
    [SerializeField] private float _normalMoveSpeed;

    [Space]
    [SerializeField] protected Vector2 _movingArea;
    protected Vector3 _currentMoveTargetPosition;
    protected NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _navMeshAgent.speed = _normalMoveSpeed;

        SetNewMovePosition();
    }

    private void Update()
    {
        if (transform.position == _navMeshAgent.pathEndPosition)
        {
            SetNewMovePosition();
        }
    }

    private void SetNewMovePosition()
    {
        _currentMoveTargetPosition = new Vector3(Random.Range(-_movingArea.x, _movingArea.x), 0, Random.Range(-_movingArea.y, _movingArea.y));

        var newPath = new NavMeshPath();
        _navMeshAgent.CalculatePath(_currentMoveTargetPosition, newPath);
        _navMeshAgent.SetPath(newPath);
    }
}
