using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Road : MonoBehaviour {
	public Transform player;

	public Transform[] segmentsPrefabs;

	private LinkedList<Transform> segments = new LinkedList<Transform>();
	public float speed = 10;
	public Vector3 movingDrection = Vector3.forward;
	public Vector3 generationDrection = Vector3.forward;
	
	public float segmentSize = 50;
	private Transform firstSegment;
	private Transform lastSegment;


	void Start(){
		for (int i = 0; i < 3; i++) {
			Transform road = (Transform)Instantiate(segmentsPrefabs[0],movingDrection * segmentSize * i,Quaternion.identity);
			road.parent = transform;
			segments.AddLast(road);
		}

	}

	void FixedUpdate(){
		foreach(Transform segment in segments){
			segment.Translate(movingDrection * (-speed),transform);
		}
	}

	void Update(){


		if(Vector3.Distance(segments.First.Value.position,transform.position)>50){
			Destroy(segments.First.Value.gameObject);
			segments.RemoveFirst();
			
			if(segments.Last.Value.GetComponent<Segment>().direction != 0){
				generationDrection = Vector3.Cross(generationDrection, segments.Last.Value.GetComponent<Segment>().direction*Vector3.up);
			}
			
			Transform road = (Transform)Instantiate(
				segmentsPrefabs[Random.Range(0,segmentsPrefabs.Length)],
				segments.Last.Value.position + generationDrection * segmentSize,
				Quaternion.LookRotation(generationDrection,Vector3.up));

			
			road.parent = transform;
			segments.AddLast(road);
		}
	}

	public void SetMovingDirection(Vector3 direction){
		movingDrection = direction;

	}

}
