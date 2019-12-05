using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;

public class IncreaseVelocityOverTimeSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		float deltaTime = Time.DeltaTime;
		
		JobHandle handle = Entities
			.WithReadOnly(deltaTime)
			.ForEach((ref SpeedIncreaseOverTimeData data, ref PhysicsVelocity vel) => 
		{
			float modifier = data.increasePerSecond * deltaTime;
			float3 newVel = vel.Linear;

			if (newVel.x > 0)
				newVel.x += modifier;
			else
				newVel.x -= modifier;

			if (newVel.y > 0)
				newVel.y += modifier;
			else
				newVel.y -= modifier;

			vel.Linear = newVel;

		}).Schedule(inputDeps);

		return handle;
	}
}
