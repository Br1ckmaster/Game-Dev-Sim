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
        if (other.tag == "EnemySpawn")
        {
            collided = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "EnemySpawn")
        {
            collided = false;
        }
    }

}
