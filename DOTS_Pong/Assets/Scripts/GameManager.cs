using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager main;

	public GameObject ballPrefab;

	public float xBound = 3f;
	public float yBound = 3f;
	public float ballSpeed = 3f;
	public float respawnDelay = 2f;
	public int[] playerScores;

	public Text mainText;
	public Text player0Text;
	public Text player1Text;

	Entity ballEntityPrefab;
	EntityManager manager;

	private void Awake()
	{
		if (main != null && main != this)
		{
			Destroy(gameObject);
			return;
		}

		main = this;
		playerScores = new int[2];

		manager = World.Active.EntityManager;
		ballEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(ballPrefab, World.Active);

		StartCoroutine(CountdownAndSpawnBall());
	}

	public void PlayerScored(int playerID)
	{
		playerScores[playerID]++;
		player0Text.text = playerScores[0].ToString();
		player1Text.text = playerScores[1].ToString();
		StartCoroutine(CountdownAndSpawnBall());
	}

	IEnumerator CountdownAndSpawnBall()
	{
		mainText.text = "Get Ready";
		yield return new WaitForSeconds(respawnDelay);

		mainText.text = "3";
		WaitForSeconds delay = new WaitForSeconds(1f);
		yield return delay;

		mainText.text = "2";

		yield return delay;

		mainText.text = "1";

		yield return delay;

		mainText.text = "";

		SpawnBall();
	}

	void SpawnBall()
	{
		Entity ball = manager.Instantiate(ballEntityPrefab);

		manager.AddComponent(ball, typeof(BallTag));

		Vector3 dir = new Vector3(UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1, UnityEngine.Random.Range(-.5f, .5f), 0f).normalized;
		Vector3 speed = dir * ballSpeed;//UnityEngine.Random.insideUnitCircle * ballSpeed;

		PhysicsVelocity velocity = new PhysicsVelocity()
		{
			Linear = speed,
			Angular = float3.zero
		};

		manager.AddComponentData(ball, velocity);
	}
}

