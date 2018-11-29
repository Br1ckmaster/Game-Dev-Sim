using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EnemyTwo : MonoBehaviour
{
    public Transform playerOne;
    public double enemyRadiusP1 = 2;
    public double enemyTrailDistance = 3;
    [HideInInspector]
    public bool idling;

    public Animator anim;
    public AudioMixerSnapshot BGM;
    public AudioMixerSnapshot ChaseMusic;

    [HideInInspector]
    public Vector3 originalPos;
    [HideInInspector]
    public Vector3 currentPos;

    [HideInInspector]
    public Quaternion originalRot;
    [HideInInspector]
    public Quaternion currentRot;

    [SerializeField]
    private Image image;

    private ChaseTwo chase;
    private PathTwo path;
    private EnemyReset reset;

    private float transitionIn;
    private float transitionOut;

    private void Awake()
    {
        originalPos = new Vector3(gameObject.transform.position.x, 
                                    0, gameObject.transform.position.z);

        originalRot = gameObject.transform.rotation;

        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);

    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        chase = GetComponent<ChaseTwo>();
        path = GetComponent<PathTwo>();
        reset = GetComponent<EnemyReset>();

        //chase.enabled = false;
        //path.enabled = false;
        reset.collided = true;
    }

    public void Update()
    {
        currentPos = new Vector3(gameObject.transform.position.x,
                                    0, gameObject.transform.position.z);

        originalRot = gameObject.transform.rotation;

        if (playerOne != null)
        {
            if (reset.collided == true && idling == false)
            {
                Idle();
                image.enabled = false;
            }
            else if (Vector3.Distance(playerOne.position, 
                        gameObject.transform.position) < enemyRadiusP1)
            {
                Chase();
                reset.collided = false;
                image.enabled = true;
            }
            else if (Vector3.Distance(playerOne.position, gameObject.transform.position)
                                        > enemyRadiusP1 + enemyTrailDistance)
            {
                PathBack();
                image.enabled = false;
            }
        }
        
    }

    private void Idle()
    {
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);

        //path.enabled = false;
        //chase.enabled = false;

        idling = true;
    }

    private void Chase()
    {
        //chase.enabled = true;
        //path.enabled = false;
        ChaseMusic.TransitionTo(transitionIn);
        chase.PlayerChaseTwo();
    }

    private void PathBack()
    {
        //path.enabled = true;
        //chase.enabled = false;
        BGM.TransitionTo(transitionOut);
        path.PathBackTwo();
        idling = false;
    }

}
