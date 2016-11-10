#pragma strict

function Start () {

}
var speed : int = 5;

function Update () {
	var x:float = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
	var z:float = Input.GetAxis("Vertical")*Time.deltaTime*speed;
	transform.Translate(x, 0, z);
}