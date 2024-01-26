using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBefSub;
    public float displacementAmt;
    public int floaters;
    public float waterDrag;
    public float waterAngularDrag;
    public WaterSurface waterSurface;
    WaterSearchParameters waterSearchParameters;
    WaterSearchResult waterSearchResult;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);
        waterSearchParameters.startPositionWS = transform.position;
        waterSurface.ProjectPointOnWaterSurface(waterSearchParameters, out waterSearchResult);

        if(transform.position.y < waterSearchResult.projectedPositionWS.y)
        {
            float displacementMulti = Mathf.Clamp01(waterSearchResult.projectedPositionWS.y - transform.position.y / depthBefSub) * displacementAmt;
            //manually add gravity
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMulti * -rb.velocity * waterDrag * Time.deltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMulti * -rb.angularVelocity * waterAngularDrag * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
    
}
