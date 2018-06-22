#pragma strict

public enum YType{
	NONE=0,
	FREEZE=1,
	GRAVITY=2,
}
// Public member data

public var patrolRoute : PatrolRoute;
public var patrolPointRadius : float = 0.5;
public var moveSpeed : float = 10;
public var angularSpeed : float = 0.3;
public var yType:YType = YType.FREEZE;
private var YPos:float;

// Private memeber data
private var character : Transform;
private var nextPatrolPoint : int = 0;
private var patrolDirection : int = 1;

function Start () {

	character = transform;
	YPos = character.position.y;
	patrolRoute.Register (transform.parent.gameObject);
}

function OnEnable () {
	nextPatrolPoint = patrolRoute.GetClosestPatrolPoint (transform.position);
}

function OnDestroy () {
	patrolRoute.UnRegister (transform.parent.gameObject);
}

function Update () {
	if (patrolRoute == null || patrolRoute.patrolPoints.Count == 0)
		return;
	
	//목표 위치와의 델타 거리 
	var targetVector : Vector3 = patrolRoute.patrolPoints[nextPatrolPoint].position - character.position;
	// 만일 목표 위치에 도달했다면 다음 목표 선정
	if (targetVector.sqrMagnitude < patrolPointRadius * patrolPointRadius) {
		nextPatrolPoint += patrolDirection;
		if (nextPatrolPoint < 0) {
			nextPatrolPoint = 1;
			patrolDirection = 1;
		}
		if (nextPatrolPoint >= patrolRoute.patrolPoints.Count) {
			if (patrolRoute.pingPong) {
				patrolDirection = -1;
				nextPatrolPoint = patrolRoute.patrolPoints.Count - 2;
			}
			else {
				nextPatrolPoint = 0;
			}
		}
	}
	
	if(yType==YType.FREEZE) targetVector.y = 0;
	// Make sure the target vector doesn't exceed a length if one
	targetVector.Normalize ();

	character.rotation = Quaternion.Lerp(character.rotation,Quaternion.LookRotation(targetVector,Vector3.up), Time.deltaTime*angularSpeed);
	character.position += character.transform.forward.normalized * Time.deltaTime * moveSpeed;
	if(yType==YType.GRAVITY) character.position += Physics.gravity*Time.deltaTime*0.1;
	
	if(yType==YType.FREEZE) character.position.y = YPos;

}
