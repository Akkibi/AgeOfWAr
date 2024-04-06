using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public int hp = 20;
    private bool isAlive = true;
    private float damageCooldown = 2f;
    private float lastDamageTime = 0f;
    public int damagePerSecond = 5;

    public string m_camp = "player";
    public Transform m_targetBase;
    public string m_type;
    private Character targetEnemy;
    private NavMeshAgent agent;


    void Start()
    {
        m_camp = this.tag;
        agent = GetComponent<NavMeshAgent>();
    }
    

    void Update()
    {
        if (isAlive)
        {
            if (targetEnemy == null)
            {
                agent.destination = m_targetBase.position;
            }
            else
            {
                agent.destination = targetEnemy.transform.position;
                if (Time.time - lastDamageTime >= damageCooldown){
                    lastDamageTime = Time.time;
                    targetEnemy.TakeDamage(damagePerSecond);
                }
            }
        }
    }

    public void SetTarget(Transform target)
    {
        this.m_targetBase = target;
        GetComponent<NavMeshAgent>().destination = target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            if (this.targetEnemy == null && !other.CompareTag(this.tag))
            {
                targetEnemy = other.gameObject.GetComponent<Character>();
            }
        }
    }

    // Function to apply damage
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    // Function to handle death
    private void Die()
    {
        isAlive = false;
        // rotate the character to 90 degrees on the x-axis in 1 second
        Destroy(gameObject);
    }
}
