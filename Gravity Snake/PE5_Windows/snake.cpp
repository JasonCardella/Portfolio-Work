#include "pch.h"
#include <iostream>
#include <conio.h>
#include "snake.h"
#include <time.h>
#include <cstdlib>
#define esc 27

using namespace std;
#pragma once
/*
	USE THIS TO DEFINE BODIES OF FUNCTIONS
*/


//Reads key presses, applies forces to move player
void applyForces(b2Body* player)
{
	char userInput;
	if (_kbhit())					//Returns true when keyboard button is pressed
	{
		userInput = _getch();		//Returns most recent char that has been pressed on keyboard

		float moveX=0.0f;
		float moveY=0.0f;
		switch (userInput)
		{
		case 'w':
		case 'W':
			moveY = 10;
			break;

		case 'a':
		case 'A':
			moveX = -10;
			break;

		case 's':
		case'S':
			moveY = -10;
			break;

		case'd':
		case'D':
			moveX = 10;

			break;

		case esc:
			cout << "You have ended the game" << endl;
			exit(0);
			break;
		}
		//cout << moveX << " " << moveY << endl;
		player->ApplyForceToCenter(b2Vec2(moveX, moveY*3), true);

	}

}

//moves target to new location
//Between -5 -> 5 on X and Y 
void moveTarget(float & xPos, float & yPos)
{
	srand(time(NULL));
	 xPos = rand() % (6 - (-5)) + (-5);
	 yPos = rand() % (6 - (-5)) + (-5);
	

}
