using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;

public class BallGoalCheckSystem : ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.WithAll<BallTag>().ForEach((Entity entity, ref Translation trans) => 
		{
			float3 pos = trans.Value;
			float bound = GameManager.main.xBound;

			if (pos.x >= bound)
			{
				GameManager.main.PlayerScored(0);
				PostUpdateCommands.DestroyEntity(entity);
			}
			else if (pos.x <= -bound)
			{
				GameManager.main.PlayerScored(1);
				PostUpdateCommands.DestroyEntity(entity);
			}
		});
	}
}
