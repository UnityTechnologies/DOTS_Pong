using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PlayerInputData : IComponentData
{
	public KeyCode upKey;
	public KeyCode downKey;
}

public struct PlayerData : IComponentData
{
	public int playerID;
}

public struct PaddleMovementData : IComponentData
{
	public int direction;
	public float speed;
}

public struct BallTag : IComponentData
{ }
