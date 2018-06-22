#pragma strict

@MenuItem ("CONTEXT/Transform/Reset Y Psotition")
static function DoubleMassFromContext (command : MenuCommand) {
    var tf : Transform = command.context;
    
	for (var child:Transform in tf) 
	{
		var rh:RaycastHit;				
		if(Physics.Raycast(child.position+Vector3.up*10,Vector3.down,rh,100)){
			Undo.RegisterUndo(child.transform,"Y Position");
			child.position = rh.point+Vector3.up.normalized*-0.7;
		}
	}
}