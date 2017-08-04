using UnityEngine;
using ZenFulcrum.Portal;

public class GravityTeleportController : TeleportController {

    private Rigidbody rb;
    public Vector3 direction = Vector3.down;
    public float scale = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    /** 
	 * Called after an object is teleported. 
	 * If your object has internal direction/rotation state, call 
	 * portal.RotateRelativeToDestination (and sometimes TeleportRelativeToDestination)
	 * to update the state to correctly reflect our new location and orientation.
	 */
    public override void AfterTeleport(Portal portal)
    {
        direction = portal.RotateRelativeToDestination(direction);
    }

    void FixedUpdate()
    {
        rb.AddForce(9.0f * scale * direction, ForceMode.Acceleration);
    }
}
