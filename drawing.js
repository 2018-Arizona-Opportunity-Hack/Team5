var canvas, context, dragging = false, dragStartLocation, snapshot;

window.onload = function(){
	var img = document.getElementById("survey");
  	var cnvs = document.getElementById("canvas");
  
 	cnvs.style.position = "absolute";
 	cnvs.style.left = img.offsetLeft + "px";
 	cnvs.style.top = img.offsetTop + "px";
	cnvs.width  = img.width;
 	cnvs.height = img.height;
}

function getCanvasCoordinates(event){
	var x = event.clientX - canvas.getBoundingClientRect().left,
	y = event.clientY - canvas.getBoundingClientRect().top;

	return {x: x, y: y};
}

function takeSnapshot(){
	snapshot = context.getImageData(0,0,canvas.width, canvas.height);
}

function restoreSnapshot(){
	context.putImageData(snapshot,0,0);
}

function draw(position){
	context.beginPath();
	context.rect(dragStartLocation.x, dragStartLocation.y, position.x-dragStartLocation.x, position.y-dragStartLocation.y);
	context.stroke();
}

function dragStart(event){
	dragging = true;
	dragStartLocation = getCanvasCoordinates(event);
	takeSnapshot();
}

function drag(event){
	var position;
	if (dragging === true){
		restoreSnapshot();
		position = getCanvasCoordinates(event);
		draw(position);
	}
}

function dragStop(event){
	dragging = false;
	restoreSnapshot();
	var position = getCanvasCoordinates(event);
	draw(position);
}

function init(){
	canvas = document.getElementById("canvas");
	context = canvas.getContext('2d');
	context.strokeStyle = 'purple';
	context.lineWidth = 2;
	context.lineCap = 'round';
	
	canvas.addEventListener('mousedown', dragStart, false);
	canvas.addEventListener('mousemove', drag, false);
	canvas.addEventListener('mouseup', dragStop, false);
}

window.addEventListener('load', init, false);