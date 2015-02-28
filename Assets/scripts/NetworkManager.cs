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
	
	// Use this for initialization
	void Start () {
		maxConn = 5;
		listenPort = 26777;
//		localIp = "192.168.0.18";
		remoteIp = "192.168.0.18";
		netOn = false;
	}

	void StartServer()
	{
		Network.InitializeServer (maxConn, listenPort, false);
	}

	void JoinServer()
	{
		Network.Connect (remoteIp, listenPort);
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initialized");
		netOn = true;
	}

	void OnConnectedToServer()
	{
		Debug.Log ("Server Joined");
		netOn = true;
	}

	
	// Update is called once per frame
	void Update () {

		bool createServ = Input.GetKeyUp ("p");
		bool joinServ = Input.GetKeyUp ("o");

		if (createServ && !netOn) {
				this.StartServer();
		}

		if (joinServ && !netOn) {
			this.JoinServer();
		}
	
	}
}
