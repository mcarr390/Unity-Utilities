using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Util 
{
    
    public static Vector3 GetClosestPointWithinRadius(Vector3 origin, Vector3 destination, float radius)
    {
        var goal = destination + radius * (origin - destination) / (origin - destination).magnitude;
        return goal;
    }

    public static Vector3 GetDirectionToTarget(Vector3 myPosition, Vector3 targetPosition)
    {
        // gets absolute direction in full vector3 format
        Vector3 direction = (targetPosition - myPosition);
        return direction;
    }
    public static Vector3 GetNormalizedDirectionToTarget(Vector3 myPosition, Vector3 targetPosition)
    {
        // gets the normalized direction
        Vector3 direction = (targetPosition - myPosition);
        return direction.normalized;
    }
    public static float GetDotProductDirectionToTarget(Transform me, Vector3 targetPosition)
    {
        // returns a number from 1 to -1 to tell us how "In front" of our position the target is
        // 1 being directly in front, -1 being behind
        Vector3 normalizedDirection = (targetPosition - me.position);
        float dot = Vector3.Dot(me.forward, normalizedDirection);
        return dot;
    }
    public static bool CheckFieldOfView(float angleFOV, float dotProductResult)
    {
        if (dotProductResult >= Mathf.Cos(angleFOV))
        {
            return true;
        }
        else return false;
    }

    public static float AngleDir (Vector3 fwd, Vector3 targetDir, Vector3 up) {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        return dir;

        // if (dir > 0) {
        //     return 1;
        // } else if (dir < 0) {
        //     return -1;
        // } else {
        //     return 0;
        // }
    }
    
    public static void RotateTowardTarget(GameObject me, GameObject target, bool onlyY, float rotationSpeed)
    {

        Quaternion desiredRotation = Quaternion.LookRotation(target.transform.position - me.transform.position);
        if (onlyY)
        {
            desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y, 0);
        }
        me.transform.rotation = Quaternion.Slerp(me.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
    public static void RotateTowardTarget(Transform me, Vector3 target, bool onlyY, float rotationSpeed)
    {

        Quaternion desiredRotation = Quaternion.LookRotation(target - me.position);
        if (onlyY)
        {
            desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y, 0);
        }
        me.rotation = Quaternion.Slerp(me.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
    Vector3 randomPoint = agent.transform.position + Random.insideUnitSphere * Range.value;
            
    NavMeshHit hit;
        if (NavMesh.SamplePosition(new Vector3(randomPoint.x, 1, randomPoint.z), out hit, 1f, NavMesh.AllAreas))
    {
        //GameObject.Instantiate(Sphere.value, hit.position + new Vector3(0, 1, 0), Quaternion.identity);

        //Debug.DrawRay(hit.position + new Vector3(0, 1, 0), Target.value.transform.position - hit.position, Color.red, 2f);

        if (Physics.Raycast(hit.position + new Vector3(0, 1, 0), (Target.value.transform.position - hit.position).normalized * 100, out RaycastHit rayHit, 100f, LineOfSightLayers.value))
        {
            if (rayHit.collider.transform.root.gameObject == Target.value.gameObject)
            {
                Debug.DrawRay(hit.position + new Vector3(0, 1, 0), (Target.value.transform.position - hit.position).normalized * 100, Color.green, 4f);

                DesiredDestination.value = hit.position;
                //Agent.value.SetDestination(hit.position);
                EndAction(true);
            }
            else
            {
                Debug.DrawRay(hit.position + new Vector3(0, 1, 0), (Target.value.transform.position - hit.position).normalized * 100, Color.red, .1f);
                EndAction(false);

            }
        }
        else
        {
            Debug.Log("raycast failed");
            EndAction(false);

        }
    }
else
{
    Debug.Log("sample pos failed");
    EndAction(false);

}
//}
        
        
}
}
