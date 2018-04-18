using Assets.Scripts.StoryFlowController;
using UnityEngine;
namespace Assets.Scripts.PlayerControls
{
    public class SimplePlayerControl: MonoBehaviour, IPlayerControllable
    {
        StoryFlowManager _flowManager;
        GameObject SceneManager;
        private void Start()
        {
            SceneManager = GameObject.FindGameObjectWithTag("Manager");
            _flowManager = SceneManager.GetComponent<StoryFlowManager>();
        }
        public void Move()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

            transform.Translate(x, 0, 0);
            transform.Translate(0, 0, y);
        }

        private void Update()
        {
            if (!_flowManager.Conversing)
                Move();
        }
    }
}
