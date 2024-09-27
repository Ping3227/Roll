using System;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    public event Action OnPlayerEnterArea; 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) 
        {
            OnPlayerEnterArea.Invoke();
            
        }
    }
}