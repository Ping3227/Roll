using UnityEngine;

public class CheckpointArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider"+other);
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player enter checkpoint area");
            GameManager.Instance.checkPointPosition = transform.position;
            
        }
    }
}