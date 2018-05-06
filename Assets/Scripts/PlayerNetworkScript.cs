using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkScript : NetworkBehaviour {

	public override void OnStartLocalPlayer(){
//		GetComponent <Controller2D> ().enabled = true;
		GetComponent <Player> ().enabled = true;
}
}
