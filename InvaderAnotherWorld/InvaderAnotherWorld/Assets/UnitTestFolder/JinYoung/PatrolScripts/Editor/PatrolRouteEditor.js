#pragma strict

@CustomEditor(PatrolRoute)
class PatrolRouteEditor extends Editor {
	public var height:float=5;
	
	function OnInspectorGUI () {
		var route : PatrolRoute = target as PatrolRoute;
		
		GUILayout.Label (route.patrolPoints.Count+" Patrol Points in Route");
		route.pingPong = EditorGUILayout.Toggle ("Ping Pong", route.pingPong);
		if (GUI.changed) {
			SceneView.RepaintAll ();
		}
		
		if (GUILayout.Button("Reverse Direction")) {
			route.patrolPoints.Reverse ();
			SceneView.RepaintAll ();
		}
		
		if (GUILayout.Button("Add Patrol Point")) {
			Selection.activeGameObject = route.InsertPatrolPointAt (route.patrolPoints.Count);
		}
		route.drawGizmos = EditorGUILayout.Toggle ("DrawGizmos", route.drawGizmos);
		route.WaypointsColor = EditorGUILayout.ColorField("WaypointsColor",route.WaypointsColor);
		
		
		if (GUILayout.Button("Choose Nearest PatrolPoint")) {
			var HandleCameraPos:Vector3 ;
			
			HandleCameraPos = SceneView.lastActiveSceneView.camera.transform.position;
			var j=0;
			for (var i : int = 1; i < route.patrolPoints.Count; i++) 
				//if (!route.patrolPoints[i]){
					if(Vector3.Distance(HandleCameraPos,route.patrolPoints[i].transform.position)
						<
						Vector3.Distance(HandleCameraPos,route.patrolPoints[j].transform.position))j=i;
				//}
			Selection.activeGameObject = route.patrolPoints[j].gameObject;
			SceneView.lastActiveSceneView.LookAt(route.patrolPoints[j].gameObject.transform.position,SceneView.lastActiveSceneView.camera.transform.rotation,30);
		}
		
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Update Position")) {
			for (i = 0; i < route.patrolPoints.Count; i++) 
			{
				var rh:RaycastHit;				
				if(Physics.Raycast(route.patrolPoints[i].transform.position,Vector3.down,rh,100)){
					Undo.RegisterUndo(route.patrolPoints[i].transform,"Patrol Path:"+route.gameObject.name+"->"+route.patrolPoints[i].name);
					route.patrolPoints[i].transform.position = rh.point+Vector3.up*height;
				}
			}
		}
		height = EditorGUILayout.FloatField("Fixed Height",height);
		GUILayout.EndHorizontal();
		
	}
	
	function OnSceneGUI () {
		var route : PatrolRoute = target as PatrolRoute;
		
		DrawPatrolRoute (route);
	}
	
	static function DrawPatrolRoute (route : PatrolRoute) {
		if (route.patrolPoints.Count == 0)
			return;
		
		var lastPoint : Vector3 = route.patrolPoints[0].transform.position;
		
		var loopCount = route.patrolPoints.Count;
		if (route.pingPong)
			loopCount--;
		
		for (var i : int = 0; i < loopCount; i++) {
			if (!route.patrolPoints[i])
				break;
			
			var newPoint = route.patrolPoints[(i + 1) % route.patrolPoints.Count].transform.position;
			if (newPoint != lastPoint) {
				Handles.color = Color (0.5, 0.5, 1.0);
				DrawPatrolArrow (lastPoint, newPoint);
				if (route.pingPong) {
					Handles.color = Color (1.0, 1.0, 1.0, 0.2);
					DrawPatrolArrow (newPoint, lastPoint);
				}
			}
			lastPoint = newPoint;
		}
	}
	
	static function DrawPatrolArrow (a : Vector3, b : Vector3) {
		var directionRotation : Quaternion = Quaternion.LookRotation(b - a);
		Handles.ConeCap (0, (a + b) * 0.5 - directionRotation * Vector3.forward * 0.5, directionRotation, 0.7);
	}
	
	@MenuItem ("Patrol/Create")
	static function DoSomething () {
		var go:GameObject;
		go = new GameObject("_new path");
		go.transform.position = Vector3.zero;
		go.transform.rotation = Quaternion.identity;
		go.AddComponent(PatrolRoute);
	}
}
