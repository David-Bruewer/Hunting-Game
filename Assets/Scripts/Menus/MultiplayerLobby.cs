using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;
public class MultiplayerLobby : MonoBehaviour
{
    [SerializeField] private NetworkRoomManager networkManager = null;
    
    
    void Update()
    {
        StartCoroutine(GetIPAddress());
    }

    IEnumerator GetIPAddress()  
    {  
        string address = "";  
        UnityWebRequest request = UnityWebRequest.Get("http://checkip.dyndns.org/");  

        yield return request.SendWebRequest();
        address = request.downloadHandler.text;
  
        int first = address.IndexOf("Address: ") + 9;  
        int last = address.LastIndexOf("</body>");  
        address = address.Substring(first, last - first);  
  
        Debug.Log(address);  
    } 

}
