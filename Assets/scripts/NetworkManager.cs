using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string srvType = "TESTGAMEHOST";
	private const string srvName = "Jean Luc Delarue";
	private int maxConn = 5;
	private int listenPort = 26777;
	private string localIp = "192.168.0.17";
	private HostData srvHost;
	private bool netOn = false;

	void StartServer()
	{
		Network.InitializeServer (maxConn, listenPort, false);
		//MasterServer.RegisterHost (srvType, srvName);
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server Initialized");
		netOn = true;
	}

	// Use this for initialization
	void Start () {
		srvHost.port=listenPort;
		srvHost.ip = localIp;
	}
	
	// Update is called once per frame
	void Update () {

		bool createServ = Input.GetKeyUp ("p");
		bool joinServ = Input.GetKeyUp ("o");

		if (createServ && !netOn) {
				this.StartServer();
		}

		if (joinServ && !netOn) {
			
		}
	
	}
}
