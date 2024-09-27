using UnityEngine;
using System;

public class AreaChecker : MonoBehaviour
{
    public event Action OnPlayerExitArea; 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            
            OnPlayerExitArea?.Invoke(); 
            
            
        }
    }
}