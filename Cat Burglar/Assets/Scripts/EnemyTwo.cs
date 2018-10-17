using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{

    public Transform playerOne;
    public Transform playerTwo;

    public float enemySpeed;
    void Update()
    {
        Vector3 directionOne = playerOne.position - this.transform.position;
        Vector3 directionTwo = playerTwo.position - this.transform.position;
        //float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(playerTwo.position, this.transform.position) < 5 /*&& angle < 30*/)
        {
            directionTwo.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionTwo), 0.1f);
            if (directionTwo.magnitude > 1)
            {
                this.transform.Translate(0, 0, enemySpeed);
            }

        }

        else if (Vector3.Distance(playerOne.position, this.transform.position) < 5 /*&& angle < 30*/)
        {
            directionOne.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionOne), 0.1f);
            if (directionOne.magnitude > 1)
            {
                this.transform.Translate(0, 0, enemySpeed);
            }

        }
        
    }
}
