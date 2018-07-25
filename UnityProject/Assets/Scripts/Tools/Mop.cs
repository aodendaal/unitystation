using Items;
using PlayGroup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mop : PickUpTrigger
{
	[SyncVar] public NetworkInstanceId ControlledByPlayer;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (ControlledByPlayer == NetworkInstanceId.Invalid)
		{
			return;
		}

		//don't start it too early:
		if (!PlayerManager.LocalPlayer)
		{
			return;
		}

		//Only update if it is inhand of localplayer
		if (PlayerManager.LocalPlayer != ClientScene.FindLocalObject(ControlledByPlayer))
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			ChatRelay.Instance.AddToChatLogClient("You mop the floor", ChatChannel.Local);
		}
	}

	#region Weapon Pooling

	//This is only called on the serverside
	public void OnAddToPool(NetworkInstanceId ownerId)
	{
		ControlledByPlayer = ownerId;
	}

	public void OnRemoveFromPool()
	{
		ControlledByPlayer = NetworkInstanceId.Invalid;
	}

	#endregion
}
