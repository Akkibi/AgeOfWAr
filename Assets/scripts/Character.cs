using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 100;

    public string m_camp = "player";

    public Transform m_targetBase;
    private Character targetEnemy;


    private NavMeshAgent agent;

    void Start()
    {
        m_camp = this.tag;
        agent = GetComponent<NavMeshAgent>();
    }

    // set target depending on current target
    void Update()
    {
        if (targetEnemy == null) {
            agent.destination = m_targetBase.position;
        } else {
            agent.destination = targetEnemy.transform.position;
        }
    }

    // set target
    public void SetTarget(Transform target)                                                             
    {
        this.m_targetBase = target;
        GetComponent<NavMeshAgent>().destination = target.position;
    }

    // set enemy as target when close
    private void OnTriggerEnter(Collider other) {
        Debug.Log("collision" + m_camp + " " + this.tag + " " + other.tag);
        if (this.targetEnemy == null) {
            if (!other.CompareTag(this.tag)) {
                this.targetEnemy = other.gameObject.GetComponent<Character>();
        }
        }
    }
}