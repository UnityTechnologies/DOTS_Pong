using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PaddleConversion : MonoBehaviour, IConvertGameObjectToEntity
{
	public int playerID;
	public float speed = 3f;
	public KeyCode upKey;
	public KeyCode downKey;

	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponentData(entity, new PlayerData { playerID = playerID });

		dstManager.AddComponentData(entity, new PaddleMovementData { direction = 0, speed = speed });

		PlayerInputData data = new PlayerInputData
		{
			upKey = upKey,
			downKey = downKey
		};
		dstManager.AddComponentData(entity, data);
	}
}
