using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameLogic
{
    public class BasicEnemy : MonoBehaviour
    {
        public float ChaseRange = 3;
        public float AttackRange = 1;

        Transform Target;
        GameObject Player;
        NavMeshAgent Agent;
        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Agent = GetComponent<NavMeshAgent>();
        }

        private void LateUpdate()
        {
            Target = Player.GetComponent<Transform>();

            Agent.destination = Target.position;
        }
    }
}
