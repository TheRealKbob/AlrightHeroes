using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	public Dictionary<Enum, State> stateMap = new Dictionary<Enum, State>();

	private State currentState;
	public State CurrentState
	{
		get{ return currentState; }
		set
		{
			if( currentState == value ) return;
			if( currentState != null )
				currentState.OnExit();
			
			currentState = value;
			currentState.OnEnter();
		}
	}

	public void Update()
	{
		if( currentState != null )
			currentState.OnUpdate();
	}

	public void AddState( Enum _enum, State _state )
	{
		if( !stateMap.ContainsKey( _enum ) )
			stateMap.Add( _enum, _state );
		else
			stateMap[ _enum ] = _state;
	}

	public void SetState( Enum _enum )
	{
		CurrentState = stateMap[ _enum ];
	}
}
