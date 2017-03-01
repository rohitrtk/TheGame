using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/// <summary>
/// Basic player movement class, extends from AbstractPlayer_Movement,
/// also handles interaction with the world (Should probably make another script for that >.>)
/// </summary>
public sealed class Player_Movement : AbstractPlayer_Movement
{
    /// <summary>
    /// Called on script init
    /// </summary>
	protected override void Start ()
    {
        if (!isLocalPlayer) return;
        
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerAttack = GetComponent<Player_Attack>();
    }
	
    /// <summary>
    /// Called once per frame
    /// </summary>
	protected override void Update ()
    {
        if (!isLocalPlayer) return;

        // Right mouse button down
        if (Input.GetMouseButtonDown(1) &&
            !EventSystem.current.IsPointerOverGameObject()) Interact();
    }

    /// <summary>
    /// Called to interact with the world
    /// </summary>
    protected override void Interact()
    {
        if (!isLocalPlayer) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, Mathf.Infinity))
        {
            GameObject rayObject = rayInfo.collider.gameObject;

            var rayDirection = rayObject.transform.position - transform.position;
            var turnDirection = Vector3.RotateTowards(transform.forward, rayDirection, Time.deltaTime * _navMeshAgent.angularSpeed, 0.0f);

            //transform.rotation = Quaternion.LookRotation(turnDirection);

            if (rayObject.tag == "Interactable")
            {
                print("Interact");
                return;
            }
            else if(rayObject.tag == "Destructable" && Vector3.Distance(gameObject.transform.position, rayObject.transform.position) < 10f)
            {
                _playerAttack.Cast("AUTO", rayObject);
                print("Auto Attack!");
                return;
            }
            
            _navMeshAgent.destination = rayInfo.point;
        }
    }
}