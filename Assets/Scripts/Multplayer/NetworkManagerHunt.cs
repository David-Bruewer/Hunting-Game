using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

/*
	Documentation: https://mirror-networking.com/docs/Components/NetworkManager.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

public class NetworkManagerHunt : NetworkManager
{
	
	public GameObject roundSystem; 



	//Called when Client attempts to join Server 
	public override void OnServerConnect(NetworkConnection conn)
	{
			
		if (roundSystem.GetComponent<RoundControl>().isGameReady)
		{
			conn.Disconnect();
		}
		
	}
	//Called when Client Joins server
	public override void OnServerAddPlayer(NetworkConnection conn)
        {
			
			//Adds Player 
			Transform startPos = GetStartPosition();
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab);

			
			//player.GetComponent<MultiplayerMovement>().networkManager = gameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
			roundSystem.GetComponent<RoundControl>().players.Add(player.GetComponent<MultiplayerMovement>());
		}


		
	//Run on Server when Client Disconnects 
    public override void OnServerDisconnect(NetworkConnection conn)
    {
		
        //SceneManager.LoadScene(4);
		if (conn.identity != null)
		{
			MultiplayerMovement mm = conn.identity.GetComponent<MultiplayerMovement>();
			roundSystem.GetComponent<RoundControl>().players.Remove(mm);

		}
        base.OnServerDisconnect(conn);
		


    }

	public override void OnClientDisconnect(NetworkConnection conn)
	{
		SceneManager.LoadScene(4);
		base.OnClientDisconnect(conn);
	}
    

}
