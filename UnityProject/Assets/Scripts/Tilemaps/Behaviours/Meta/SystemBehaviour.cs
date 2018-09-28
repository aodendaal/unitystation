﻿using UnityEngine;


public abstract class SystemBehaviour : MonoBehaviour
	{
		protected MetaDataLayer metaDataLayer;
		protected MetaTileMap metaTileMap;

		public void Awake()
		{
			metaDataLayer = GetComponentInChildren<MetaDataLayer>();
			metaTileMap = GetComponentInChildren<MetaTileMap>();
			
			GetComponent<SystemManager>().Register(this);
		}

		public abstract void Initialize();

		public abstract void UpdateAt(Vector3Int position);
	}
