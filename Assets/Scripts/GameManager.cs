using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public enum GameState
	{
		IDLE,
		MOVING,
		BATTLE
	}

	public static GameManager Instance;

	public StateMachine stateMachine = new StateMachine();

	public CharacterManager characterManager;
	public static CharacterManager CharacterManager{ get{ return Instance.characterManager; } }

	void Awake()
	{
		if( Instance == null )
			Instance = this;
		else if( Instance != this )
			Destroy( gameObject );	
		
		// Add Game States
		stateMachine.AddState( GameState.IDLE, new IdleGameState() );
	}
	
	void OnEnable()
	{
		
		StartCoroutine( GameLoop() );

	}

	public IEnumerator GameLoop()
	{
		yield return StartCoroutine( GameStarting() );
		yield return StartCoroutine( GamePlaying() );
		yield return StartCoroutine( GameEnding() );
	}

	public IEnumerator GameStarting()
	{
		stateMachine.SetState( GameState.IDLE );
		yield return new WaitForSeconds( 3 );
	}

	public IEnumerator GamePlaying()
	{
		yield return new WaitForSeconds( 3 );
	}

	public IEnumerator GameEnding()
	{
		yield return new WaitForSeconds( 3 );
	}
}
