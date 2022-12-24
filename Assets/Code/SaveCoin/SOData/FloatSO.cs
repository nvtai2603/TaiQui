using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
	[SerializeField]
	private float _coin;

    public float Coin
	{
		get { return _coin; }
		set { _coin = value; }
	}

	
}
