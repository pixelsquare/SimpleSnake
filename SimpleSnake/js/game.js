// General properties
var WIDTH = 540;
var HEIGHT = 540;

// Canvas setup
var canvas = document.createElement("canvas");
canvas.width = WIDTH;
canvas.height = HEIGHT;
var ctx = canvas.getContext("2d");
document.body.appendChild(canvas);

/*
* Constructor Method that is responsible
* to all our images. It is dynamic so that
* we can adjust the image position, scale, etc.
*/
function imageLoader(src) {
	var init = false,
		image = new Image();

	image.onload = function () {
		init = true;
	}

	image.src = src;

	this.properties = {
		positionX: 0,
		positionY: 0,
		scaleX: 1,
		scaleY: 1
	};

	this.getWidth = function () {
		return image.width;
	}

	this.getHeight = function () {
		return image.height;
	}

	this.draw = function () {
		if (init) {
			ctx.save();
			ctx.translate(this.properties.positionX, this.properties.positionY);
			ctx.scale(this.properties.scaleX, this.properties.scaleY);
			ctx.drawImage(image, 0, 0);
			ctx.restore();
		}
	}

	this.hasCollidedWith = function (obj) {
		if (this.properties.positionX <= (obj.properties.positionX + 30) && obj.properties.positionX <= (this.properties.positionX + 30) &&
			this.properties.positionY <= (obj.properties.positionY + 30) && obj.properties.positionY <= (this.properties.positionY + 30)) {
			return true;
		}
		else return false;
	}
}

/*
* Event Listener for our function "keyHandler" down below
* Responsible for key presses
*/
addEventListener("keydown", keyHandler, true);

/*
* background reference
*/
var background = new imageLoader("images/bg.png");

/*
* default number of slices our snake has
*/
var DEFAULT_LENGTH = 5;
var snakeLength = 5;

/*
* snake array
*/
var snake = [];

/*
* snake head and tail reference
*/
var snakeHead;
var snakeTail;
var snakeTailIndx;
var snakeSize = 32;

/*
* tail		  head
* ----  ----  ----
* |  |  |  |  |  |
* ----  ----  ----
*/

/*
* Is our snake dead
*/
var dead = false;

/* 
* Checker to prevent the snake 
* from taking the opposite route
*/
var hasMoved = false;

/*
* Snake's direction
*/
var direction = {
	left: 1,
	right: 2,
	top: 3,
	bottom: 4
};
var dir;

/*
* Snake food reference
*/
var snakeFood = new imageLoader("images/snakefood.png");
var foodSize = 30;

/*
* Score handler
*/
var score;

function init() {
	for (i = 0; i < snakeLength; i++) {
		snake.push(new imageLoader("images/snaketile.png"));
		snake[i].properties.positionX = ((snakeLength - 1) - i) * snakeSize;
	}

	snakeLength = DEFAULT_LENGTH;
	snakeHead = snake[0];
	snakeTailIndx = snakeLength - 1;
	snakeTail = snake[snakeTailIndx];

	dir = direction.right;
	score = 0;
	spawnFood();
}

var autoMove = function () {
	if (dir == direction.left) {
		snakeTail.properties.positionX = snakeHead.properties.positionX - snakeHead.getWidth() - 2;
		snakeTail.properties.positionY = snakeHead.properties.positionY;
	}
	else if (dir == direction.right) {
		snakeTail.properties.positionX = snakeHead.properties.positionX + snakeHead.getWidth() + 2;
		snakeTail.properties.positionY = snakeHead.properties.positionY;
	}
	else if (dir == direction.top) {
		snakeTail.properties.positionY = snakeHead.properties.positionY - snakeHead.getHeight() - 2;
		snakeTail.properties.positionX = snakeHead.properties.positionX;
	}
	else if (dir == direction.bottom) {
		snakeTail.properties.positionY = snakeHead.properties.positionY + snakeHead.getHeight() + 2;
		snakeTail.properties.positionX = snakeHead.properties.positionX;
	}

	hasMoved = true;
	snakeHead = snakeTail;
	snakeTailIndx--;
	if (snakeTailIndx < 0)
		snakeTailIndx = snakeLength - 1;
	snakeTail = snake[snakeTailIndx];

	if (snakeHead.hasCollidedWith(snakeFood)) {
		addSnakeLength();
		spawnFood();
		score++;
	}
	else
		selfCollision();
};

var checkArenaCollision = function () {
	if (dir == direction.right && snakeHead.properties.positionX > WIDTH ||
		dir == direction.left && snakeHead.properties.positionX < 0 ||
		dir == direction.bottom && snakeHead.properties.positionY > HEIGHT ||
		dir == direction.top && snakeHead.properties.positionY < 0)
		dead = true;
}

var selfCollision = function () {
	for (i = 0; i < snake.length; i++) {
		if (snakeHead.hasCollidedWith(snake[i]) && snakeHead != snake[i])
			reset();
	}
}

var spawnFood = function () {
	snakeFood.properties.positionX = foodSize + (Math.random() * (WIDTH - (foodSize * 2)));
	snakeFood.properties.positionY = foodSize + (Math.random() * (HEIGHT - (foodSize * 2)));
};

var addSnakeLength = function () {
	var tmpTile = new imageLoader("images/snaketile.png");
	tmpTile.properties.positionX = snakeHead.properties.positionX;
	tmpTile.properties.positionY = snakeHead.properties.positionY;
	snake.push(tmpTile);
	snakeLength = snake.length;
};

var reset = function () {
	dead = false;

// ----- NEW !!!!
	snakeLength = DEFAULT_LENGTH;
	snake = snake.slice(0, snakeLength);

	for (i = 0; i < snake.length; i++) {
		snake[i].properties.positionX = ((snakeLength - 1) - i) * snakeSize;
		snake[i].properties.positionY = 0;
	}

// -----
	snakeHead = snake[0];
	snakeTailIndx = snakeLength - 1;
	snakeTail = snake[snakeTailIndx];

	dir = direction.right;
	score = 0;
	spawnFood();
};

// Game loop
var update = function (dt) {
	checkArenaCollision();

	if (dead) {
		reset();
	}
};

function keyHandler(e) {
	switch (e.keyCode) {
		case 37: // Left
			if (hasMoved && dir != direction.right)
				dir = direction.left;
			break;

		case 38: // Top
			if (hasMoved && dir != direction.bottom)
				dir = direction.top;
			break;

		case 39: // Right
			if (hasMoved && dir != direction.left)
				dir = direction.right;
			break;

		case 40: // Down
			if (hasMoved && dir != direction.top)
				dir = direction.bottom;
			break;
	}

	hasMoved = false;
}

var render = function () {
	ctx.clearRect(0, 0, canvas.width, canvas.height);
	background.draw();
	snakeFood.draw();

	for (i = 0; i < snake.length; i++) {
		snake[i].draw();
	}

	ctx.fillStyle = "rgb(0, 0, 250)";
	ctx.font = "20px Helvetica";
	ctx.textAlign = "left";
	ctx.textBaseline = "top";
	ctx.fillText("Score: " + score, 5, 515);
};

var then = Date.now();

var main = function () {
	var now = Date.now();
	var delta = now - then;
	update(delta / 1000);

	render();
	then = now;
};

init();
/*
* Sets the speed of the snake
*/
setInterval(autoMove, 100);

/*
* Sets the speed on how fast arena collision will check
*/
setInterval(main, 1);