using UnityEngine;

public class Fan : MonoBehaviour
{
    public float maxForce = 10f;
    public float maxDistance = 5f;
    public Vector3 direction;
    public LayerMask affectedLayers; 

    private void FixedUpdate()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, maxDistance, affectedLayers);
        foreach (Collider col in objectsInRange)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                float forceAmount = Mathf.Lerp(maxForce, 0, distance / maxDistance);
                

                
                if (col.CompareTag("Player"))
                {
                    Debug.Log("Player");
                    forceAmount /= rb.mass;
                }

                rb.AddForce(direction * forceAmount, ForceMode.Force);
            }
        }
    }
}