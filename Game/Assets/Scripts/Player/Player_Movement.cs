using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player_Movement : AbstractPlayer_Movement
{
	protected override void Start ()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	protected override void Update ()
    {
        // Right mouse button down
        if (Input.GetMouseButtonDown(1) &&
            !EventSystem.current.IsPointerOverGameObject()) Interact();
    }

    protected override void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;
        if (Physics.Raycast(ray, out rayInfo, Mathf.Infinity))
        {
            GameObject rayObject = rayInfo.collider.gameObject;

            if (rayObject.tag == "Interactable")
            {
                print("Interact");
                return;
            }

            _navMeshAgent.destination = rayInfo.point;
        }
    }
}
