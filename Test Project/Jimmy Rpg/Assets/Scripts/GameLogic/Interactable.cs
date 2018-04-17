using Assets.Scripts.StoryFlowController;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GameLogic
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        //IStoryFlowManager _storyFlowManager;
        //public GameObject Canvas;

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                Interact();
            }

        }
        public void Interact()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Interacting");
               // Canvas = GameObject.Find("Test");
               // _storyFlowManager.FillCanvas(Canvas);
            }
        }
    }
}