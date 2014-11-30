using UnityEngine;
using System.Collections;

public class MousePaintBehaviour : MonoBehaviour {
	
	#region Fields
    public GameObject Prefab;
	private Plane plane;
	private Ray ray;
	private float raycast;
	private float distance;
	private Vector3 currentMousePosition;
	private Vector3 newPosition;
	private Vector3 oldPrefabPosition;
	private bool first = true;
	#endregion
	
	// Use this for initialization
    void Awake() {	
		#region take this plane to place Prefab always othogonal to camera
//		plane = new Plane((Camera.mainCamera.transform.forward).normalized, new Vector3(0,0,0));
		#endregion
		
		#region take this plane to place Prefab always on x-z-plane
		plane = new Plane(Vector3.up.normalized, new Vector3(0,0,0));
		#endregion
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			PaintPrefab();
		}
		else{
			first = true;
		}
	}
	
	private void PaintPrefab(){
		currentMousePosition = Input.mousePosition;
		ConvertScreenPointToRay();
		distance = Vector3.Distance(newPosition,oldPrefabPosition);
		if (first) {
			Instantiate(Prefab,newPosition,Quaternion.identity);
			oldPrefabPosition = newPosition;
			first = false;
		}
		if (distance > Prefab.renderer.bounds.extents.magnitude) {
			float step = 1F/(distance); 
			for(float i = 0; i <=1; i+=step){
				Vector3 tmp = oldPrefabPosition + (oldPrefabPosition-newPosition)*i;
				Instantiate(Prefab,tmp,Quaternion.identity);				
			}
			oldPrefabPosition = newPosition;
		}
	}
	
	private void ConvertScreenPointToRay(){
		ray = Camera.mainCamera.ScreenPointToRay(currentMousePosition);
		plane.Raycast(ray, out raycast);
		newPosition = ray.GetPoint(raycast);
	}
}