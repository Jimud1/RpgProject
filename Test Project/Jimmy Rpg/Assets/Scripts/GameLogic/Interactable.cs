using Assets.Scripts.StoryFlowController;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        GameObject SceneManager;
        StoryFlowManager _flowManager;

        private void Start()
        {
            SceneManager = GameObject.FindGameObjectWithTag("Manager");
            _flowManager = SceneManager.GetComponent<StoryFlowManager>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                Interact();
            }
        }

        public void Interact()
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!_flowManager.Conversing)
                    _flowManager.FillCanvas();
            }
        }
    }
}