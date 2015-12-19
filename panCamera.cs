using UnityEngine;
using System.Collections;

public class panCamera : MonoBehaviour {

	bool lookAtClue;
	Quaternion needRo;

	// Use this for initialization
	void Start () {
		lookAtClue = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAtClue) 
		{
			
			
			gameObject.transform.rotation=Quaternion.Slerp(gameObject.transform.rotation, needRo, Time.deltaTime * 3);
			
			
		}

	
	}
	public void panCameraTo(GameObject obj, float time)
	{
		lookAtClue = true;
		slowLookAt (obj.transform.position, time);
	}

	void slowLookAt(Vector3 pos,float time)
	{
		
		
		enableCamera (false,true);
		needRo=Quaternion.LookRotation(pos - gameObject.transform.position);
		lookAtClue = true;
		StartCoroutine(WaitForLook(time));
		
	}
	
	void enableCamera(bool value1,bool value2){
		
		gameObject.GetComponent<MouseLook> ().enabled = value1;
		gameObject.GetComponent<CharacterController>().enabled=value2;
		
		
	}
	
	IEnumerator WaitForLook(float time) 
	{
		
		yield return new WaitForSeconds(time);
		enableCamera (true,true);
		lookAtClue = false;
		
	}
}
