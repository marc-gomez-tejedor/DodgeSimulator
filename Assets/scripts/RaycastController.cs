using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public MovementBehavior movementBehavior;
    public ParticleController particleController;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Floor") // Assuming the floor has the tag "Floor"
                {
                    Vector3 targetPosition = hit.point;
                    movementBehavior.MoveToPosition(targetPosition);
                    particleController.MoveAndPlay(targetPosition);
                }
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementBehavior.Stop();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Floor") // Assuming the floor has the tag "Floor"
                {
                    Vector3 targetPosition = hit.point;
                    movementBehavior.DashTo(targetPosition);
                }
            }
        }
        
    }
}
