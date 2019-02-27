/*
	USE THIS TO PLAY GAME
*/
#include "pch.h"
#include "snake.h"
#include <iostream>
#include<Box2D\Box2D.h>
#include<random>
#include<time.h>
#include <conio.h>

#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
using namespace std;

int main()
{
	cout << "Welcome to Gravity Snake!\nUse WASD to move the snake, hit the target to score points!" << endl;
	cout << "Press enter to start the game!" << endl;
	bool play = true;

	
	//Enables game loop
	

	//Creating World
	b2Vec2 gravity(0.0f, -0.02f);						
	b2World* world = new b2World(gravity);

	//SNAKE CREATION

		//Creating Dynamic Body
		b2BodyDef bodyDef;
		bodyDef.type = b2_dynamicBody;
		bodyDef.position.Set(2.5f, 2.5f);
		b2Body* body = (*world).CreateBody(&bodyDef);

		//Create and attach polygon shape
		b2PolygonShape dynamicBox;
		dynamicBox.SetAsBox(1.0f, 1.0f);

		//Create fixture def  using box
		b2FixtureDef fixtureDef; 
		fixtureDef.shape = &dynamicBox;
		fixtureDef.density = 1.0f;
		fixtureDef.friction = 0.3f;
		//creates actual fixture
		body->CreateFixture(&fixtureDef);

	//GROUND WALL
		b2BodyDef groundBodyDef;
		groundBodyDef.position.Set(0.0f, -6.0f);
		b2Body* groundBody = (*world).CreateBody(&groundBodyDef);

		b2PolygonShape groundBox;
		groundBox.SetAsBox(7.5f, 0.0f);	//10 long 1 high
		groundBody->CreateFixture(&groundBox, 0.0f);


	//TOP WALL
		b2BodyDef topBodyDef;
		topBodyDef.position.Set(0.0f, 6.0f);
		b2Body* topBody = (*world).CreateBody(&topBodyDef);

		b2PolygonShape topBox;
		topBox.SetAsBox(7.5f,0.0f);
		topBody->CreateFixture(&topBox, 0.0f);

	//LEFT WALL
		b2BodyDef leftBodyDef;
		leftBodyDef.position.Set(-6.0f, 0.0f);
		b2Body* leftBody = (*world).CreateBody(&leftBodyDef);

		b2PolygonShape leftBox;
		leftBox.SetAsBox(0.0f, 7.5f);
		leftBody->CreateFixture(&leftBox, 0.0f);

	//RIGHT WALL
		b2BodyDef rightBodyDef;
		rightBodyDef.position.Set(6.0f, 0.0f);
		b2Body* rightBody = (*world).CreateBody(&rightBodyDef);

		b2PolygonShape rightBox;
		rightBox.SetAsBox(0.0f, 7.5f);
		rightBody->CreateFixture(&rightBox, 0.0f);
		

	//Setting up world.step
	float32 timeStep = 1.0f / 60.0f;
	int velocityIterations = 6;
	int positionIterations = 2;

	
	
	//Create vector for the target
	b2Vec2 target = b2Vec2(0, 0);
	moveTarget(target.x, target.y);

	//Score var to keep track of how many targets player has hit
	int score = 0;

	//Temp loop to siumulate snake falling
	//At the current time - movement works
	//TODO:add target, movetarget, add scoring
	while(play)
	{
		(*world).Step(timeStep, velocityIterations, positionIterations);
		b2Vec2 position = body->GetPosition();
		float angle = body->GetAngle();
		cout << "Snake: ";
		printf("%4.2f %4.2f", position.x, position.y);
		cout << "-->Target: " << target.x << "," << target.y << "\t Score: "<<score<< endl;
		//system("cls");
		//cout << "Snake: " << position.x << "," << position.y << endl;

		applyForces(body);
		
		//Checking if snake is close enough to target, then adds a score
		if (b2Distance(target, body->GetPosition())<0.4f)
		{
			moveTarget(target.x, target.y);
			score++;
		}
		if (score >= 5)
		{
			
			play=false;
		}
	}
	cout << "You got all 5 targets! Congrats!" << endl;
	//Since all the pointers are contained in the "world" i just have to delete world and everything else goes with it 
	delete world;
	_CrtDumpMemoryLeaks();
}