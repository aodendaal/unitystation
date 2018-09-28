﻿using UnityEngine;
using UnityEngine.Networking;

	/// Provides the higher level multi matrix detection system to the
	/// playermove component using cross-matrix methods
	public class PlayerMatrixDetector : NetworkBehaviour {
		public bool CanPass( Vector3Int localPos, Vector3Int direction, Matrix currentMatrix ) {
			MatrixInfo matrixInfo = MatrixManager.Get( currentMatrix );
			if ( matrixInfo.MatrixMove ) {
				//Converting local direction to world direction
				direction = Vector3Int.RoundToInt( matrixInfo.MatrixMove.ClientState.Orientation.Euler * direction );
			}
			Vector3Int position = MatrixManager.LocalToWorldInt( localPos, MatrixManager.Get( currentMatrix ) );

			if ( !MatrixManager.IsPassableAt( position, position + direction ) ) {
				return false;
			}

			return true;
		}
	}