using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class CharacterManager
{


	public void SelectCharacter( Character _c )
	{
		Debug.Log( _c.characterClass.name + " Character Selected: " + _c.name );
	}
}
