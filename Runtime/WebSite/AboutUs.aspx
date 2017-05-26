﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="web_AboutUs" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="scripts/lib/jquery-1.11.3.min.js"></script>
<style type="text/css">
    html, body { margin:0;padding:0;width:100%;height:100%; }
    canvas { position:absolute;left:0;bottom:0; }
    div, p { text-align:center; }
    .dev { margin:0 auto;padding-top:80px; }
</style>
	<script type="text/javascript">
		var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
		document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
		</script>
	<script src="scripts/ga.js" type="text/javascript"></script>
	<script type="text/javascript">
		try {
			var pageTracker = _gat._getTracker("UA-15240703-1");
			pageTracker._trackPageview();
		} catch (err) { }
	</script>
</head>

<body style="overflow:hidden">

<canvas id="canvasElement" width="1303" height="663">Your browser does not support the Canvas element.</canvas>
		
<!-- Load scripts -->
<script type="text/javascript">
			
	var particles = [];
	for( var i = 0; i < 100; i++ ) {
		particles.push( { 
			x:Math.random()*window.innerWidth, 
			y:Math.random()*window.innerHeight, 
			vx:(Math.random()*2)-1, 
			vy:(Math.random()*2-1),
			history: [],
			size: 4+Math.random()*6,
			color: Math.random() > .5 ? "#000000" : Math.random() > .5 ? "#FF0000" : "#FFFF00"
		} );
	}
			
	var mouse = { x: 0, y: 0 };
			
	var canvas = document.getElementById('canvasElement');
			
	if (canvas && canvas.getContext) {
		var context = canvas.getContext('2d');
				
		Initialize();
	}
			
	function Initialize() {
		canvas.addEventListener('mousemove', MouseMove, false);
		window.addEventListener('resize', ResizeCanvas, false);
		setInterval( TimeUpdate, 20 );
				
		context.beginPath();
				
		ResizeCanvas();
	}
			
	function TimeUpdate(e) {
				
		context.clearRect(0, 0, window.innerWidth, window.innerHeight);
				
		for( var i = 0; i < particles.length; i++ ) {
			particles[i].x += particles[i].vx;
			particles[i].y += particles[i].vy;
					
			if( particles[i].x > window.innerWidth ) {
				particles[i].vx = -1-Math.random();
			}
			else if ( particles[i].x < 0 ) {
				particles[i].vx = 1+Math.random();
			}
			else {
				particles[i].vx *= 1 + (Math.random()*0.005);
			}
					
			if( particles[i].y > window.innerHeight ) {
				particles[i].vy = -1-Math.random();
			}
			else if ( particles[i].y < 0 ) {
				particles[i].vy = 1+Math.random();
			}
			else {
				particles[i].vy *= 1 + (Math.random()*0.005);
			}
					
			context.strokeStyle = particles[i].color;
			context.beginPath();
			for( var j = 0; j < particles[i].history.length; j++ ) {
				context.lineTo( particles[i].history[j].x, particles[i].history[j].y );
			}
			context.stroke();
					
			particles[i].history.push({	x: particles[i].x, y: particles[i].y });
			if( particles[i].history.length > 45 ) {
				particles[i].history.shift();
			}
					
			var distanceFactor = DistanceBetween( mouse, particles[i] );
			distanceFactor = Math.max( Math.min( 15 - ( distanceFactor / 10 ), 10 ), 1 );
					
			context.fillStyle = particles[i].color;
			context.beginPath();
			context.arc(particles[i].x,particles[i].y,particles[i].size*distanceFactor,0,Math.PI*2,true);
			context.closePath();
			context.fill();
					
		}
	}
			
	function MouseMove(e) {
		mouse.x = e.layerX;
		mouse.y = e.layerY;
				
		//context.fillRect(e.layerX, e.layerY, 5, 5);
		//Draw( e.layerX, e.layerY );
	}
			
	function Draw( x, y ) {
		context.strokeStyle = '#ff0000';
		context.lineWidth = 4;
		context.lineTo(x, y);
		context.stroke();
	}
			
	function ResizeCanvas(e) {
		canvas.width = window.innerWidth;
		canvas.height = window.innerHeight;
	}
			
	function DistanceBetween(p1,p2) {
		var dx = p2.x-p1.x;
		var dy = p2.y-p1.y;
		return Math.sqrt(dx*dx + dy*dy);
	}
</script>
<div class="dev">
    <div>开发者：</div>
    <p>李萨、杨华东、张小波</p>
    <div>技术支持：pcx.cn</div>
</div>

</body>
</html>
