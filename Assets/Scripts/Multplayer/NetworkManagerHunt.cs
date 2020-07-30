using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

/*
	Documentation: https://mirror-networking.com/docs/Components/NetworkManager.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

public class NetworkManagerHunt : NetworkManager
{
	
	//Adding round system Object 
	


	//Called when Client Joins server
	public override void OnServerAddPlayer(NetworkConnection conn)
        {
			//Adds Player 
			Transform startPos = GetStartPosition();
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab);

			

            NetworkServer.AddPlayerForConnection(conn, player);

			if (numPlayers == maxConnections)
			{
				StartCoroutine(RoundSystem.StartRound());
			}

		}

	public override void OnServerDisconnect(NetworkConnection conn)
        {	
			//Last Player 
			if(numPlayers == 1)
			{
				Debug.Log("Hell yeah you fuckin won");
				RoundSystem.EndRound();
			}

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }

}
