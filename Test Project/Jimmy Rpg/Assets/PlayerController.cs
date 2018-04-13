using UnityEngine;


namespace Assets
{
    class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

            transform.Translate(x, 0, 0);
            transform.Translate(0, 0, y);
        }
    }
}
