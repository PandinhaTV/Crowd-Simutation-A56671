using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	public GameObject[] goalLocations;
	NavMeshAgent agent;
	private Animator anim;

	// Use this for initialization
	void Start () {

		agent = this.GetComponent<NavMeshAgent>();
		goalLocations = GameObject.FindGameObjectsWithTag("Goal");
		int i = Random.Range(0,goalLocations.Length);
		agent.SetDestination(goalLocations[i].transform.position);
		anim= this.GetComponent<Animator>();
		anim.SetTrigger("isWalking");
		anim.SetFloat("wOffset", Random.Range(0f,1.0f));
		float sm =  Random.Range(0.5f,2f);
		anim.SetFloat("speedMult",sm);
		agent.speed *= sm;
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 1)
		{
			int i = Random.Range(0,goalLocations.Length);
			agent.SetDestination(goalLocations[i].transform.position);
		}
	}
}
