#pragma once
/*
	USE THIS TO DECLARE FUNCTIONS
*/
#include <Box2D\Box2D.h>

void update();

void display();

void applyForces(b2Body* player);

void moveTarget(float& xPos, float& yPos);
	