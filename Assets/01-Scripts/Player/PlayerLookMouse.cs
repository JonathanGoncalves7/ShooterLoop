using UnityEngine;

public class PlayerLookMouse : MonoBehaviour
{
    private void Update()
    {
        LookMouse();
    }

    private void LookMouse()
    {
        Vector3 mouse = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mouse);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mouse.z = hit.distance;
        }

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouse);
        mouseWorld.y = transform.position.y;
        transform.LookAt(mouseWorld);
    }
}
