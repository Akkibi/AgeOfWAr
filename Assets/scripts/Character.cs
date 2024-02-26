using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 100;

    public string camp = "Player";

    private Transform targetBase;
    private Character targetEnemy;


    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null) {
            agent.destination = targetBase.position;
        } else {
            agent.destination = targetEnemy.transform.position;
        }
    }
    public void SetTarget(Transform target)                                                             
    {
        this.targetBase = target;
        GetComponent<NavMeshAgent>().destination = target.position;
    }

     void OnTriggerEnter(Collider other) {
        
        if (this.targetEnemy == null) {
            if (other.CompareTag("Enemy")) {
                this.targetEnemy = other.gameObject.GetComponent<Character>();
        }
        }
    }
}


// 