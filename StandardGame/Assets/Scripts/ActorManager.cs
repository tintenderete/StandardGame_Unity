﻿using UnityEngine;
using System.Collections;
using BoardGameApi;

public class ActorManager
{
	public Transform transform;
	public GameObject go;
	public int id;

	public ActorManager(GameObject go)
	{
		this.go = go;
		this.transform = go.transform;
	}


}
