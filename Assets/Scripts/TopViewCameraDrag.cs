using UnityEngine;

public class TopViewCameraDrag : MonoBehaviour
{
    [SerializeField] private float _dragSpeed = 2;
    [SerializeField] private Camera _targetCamera;


    private Vector3 dragOrigin;


    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1100) && hit.collider.gameObject.tag == "Ipad")
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;

                return;
            }
            
            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = _targetCamera.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.y * _dragSpeed, 0, pos.x * _dragSpeed);

            transform.Translate(move, Space.World);

        }

    }
}