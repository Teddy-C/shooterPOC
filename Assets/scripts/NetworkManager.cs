using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

//	private const string srvType = "TESTGAMEHOST";
//	private const string srvName = "Jean Luc Delarue";
	private int maxConn;
	private int listenPort;
//	private string localIp;
	private string remoteIp;
	private bool netOn;
	public GameObject playerPrefab;
	
	// Use this for initialization
	void Start () {
		maxConn = 5;
		listenPort = 26777;
//		localIp = "192.168.0.18";
		remoteIp = "127.0.0.1";
		netOn = false;
	}

	void StartServer()
	{
		Network.InitializeServer (maxConn, listenPort, false);
	}

	void JoinServer()
	{
		//super long... si ce n'est impossible
		Network.Connect (remoteIp, listenPort);
		Debug.Log ("I am connecting");
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initialized");
		SpawnPlayer ();
		netOn = true;
	}

	void OnConnectedToServer()
	{
		Debug.Log ("Server Joined");
		SpawnPlayer ();
		netOn = true;
	}

	void OnPlayerConnected(NetworkPlayer player)
	{
		Debug.Log ("Player connected from " + player.ipAddress + ":" + player.port);
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log ("Player disconnected from " + player.ipAddress + ":" + player.port);
		Network.RemoveRPCs (player);
		Network.DestroyPlayerObjects (player);
	}

	void StopClient() {
		this.netOn = false;
		Network.Disconnect ();
		Debug.Log ("Client Stopped");
	}

	private void SpawnPlayer()
	{
		Network.Instantiate (playerPrefab, new Vector3 (0f, 1f, 0f), Quaternion.identity, 0);
	}
	
	void Update () {

		bool createServ = Input.GetKeyUp (KeyCode.P);
		bool joinServ = Input.GetKeyUp (KeyCode.O);


		if (Input.GetKeyUp (KeyCode.Escape)) {
			this.StopClient();
		}

		if (createServ && !netOn) {
			this.StartServer();
		}

		if (joinServ && !netOn) {
			this.JoinServer();
		}
	
	}
}
