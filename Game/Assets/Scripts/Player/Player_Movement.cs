using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public sealed class Player_Movement : AbstractPlayer_Movement
{
	protected override void Start ()
    {
        if (!isLocalPlayer) return;

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _attack = new Player_Attack();
    }
	
	protected override void Update ()
    {
        if (!isLocalPlayer) return;

        // Right mouse button down
        if (Input.GetMouseButtonDown(1) &&
            !EventSystem.current.IsPointerOverGameObject()) Interact();
    }

    protected override void Interact()
    {
        if (!isLocalPlayer) return;

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
            else if(rayObject.tag == "Destructable" && Vector3.Distance(gameObject.transform.position, rayObject.transform.position) < 10f)
            {
                _attack.AutoAttack(rayObject);
                print("Auto Attack!");
                return;
            }
            
            _navMeshAgent.destination = rayInfo.point;
        }
    }
}
