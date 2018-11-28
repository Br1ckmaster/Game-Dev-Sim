using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    [HideInInspector]
    public bool collided;

	public void Update()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            collided = true;
            Debug.Log("Collided");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Enemy")
        {
            collided = false;
            Debug.Log("Left Collision");
        }
    }

}
