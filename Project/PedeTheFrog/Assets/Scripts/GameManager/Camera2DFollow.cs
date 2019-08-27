using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public Transform m_targetToFollow;
	//public float m_damping = 1;
	//public float m_lookAheadFactor = 3;
	//public float m_lookAheadReturnSpeed = 0.5f;
	//public float m_lookAheadMoveThreshold = 0.1f;
	//public float yPosRestriction = -1;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	//Vector3 currentVelocity;
	//Vector3 lookAheadPos;

	float nextTimeToSearch = 0;
	
	void Start () {
		lastTargetPosition = m_targetToFollow.position;
		offsetZ = (transform.position - m_targetToFollow.position).z;
		transform.parent = null;
	}
	
	void Update () {

		if (m_targetToFollow == null) {
			FindPlayer ();
			return;
		}

		// only update lookahead pos if accelerating or changed direction
        /*
		float xMoveDelta = (m_targetToFollow.position - lastTargetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > m_lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = m_lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * m_lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = m_targetToFollow.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, m_damping);

		newPos = new Vector3 (newPos.x, Mathf.Clamp (newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

		transform.position = newPos;
	    */	

		lastTargetPosition = m_targetToFollow.position;
	}

	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
			if (searchResult != null)
				m_targetToFollow = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}
