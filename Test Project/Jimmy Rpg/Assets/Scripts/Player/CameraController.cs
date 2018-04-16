using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CameraController : MonoBehaviour
    {
        GameObject player;
        Vector3 offset;

        // Use this for initialization
        void Start()
        {
            //Set who the player is
            player = GameObject.FindGameObjectWithTag("Player");
            //Set off set from player to camera
            offset = transform.position - player.transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}
