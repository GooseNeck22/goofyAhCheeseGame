using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Transform> targets = new List<Transform> ();
    private Transform _primaryTarget;
 
//finds an important target to focus on and caches the reference
    public Transform Target
    {
        get
        {
            if(_primaryTarget==null)
            {
                // clean the targets list by removing each target transform
                // that is nulled due to the gameobject already being destroyed
                targets.RemoveAll(eachTarget => {return eachTarget == null;});
 
                if(targets.Count>0)
                {
                    // find the first element that would cause the lambada to return true
                    // you can change this later to allow the tower to prioritize different targets
                    _primaryTarget = targets.Find(target => {return true;});
                }
            }
 
            return _primaryTarget;
        }
    }
 
 
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Enemy"))
        {
            targets.Add(other.transform);
        }
    }
 
 
 
    void OnTriggerExit(Collider other)
    {
        //in case it was the primary target that leaves the Tower's range
        if(ReferenceEquals(_primaryTarget,other.transform))
        {
            _primaryTarget = null;
        }
 
        targets.Remove(other.transform);
    }
}