using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomScene : MonoBehaviourPunCallbacks
{
    private void Start() {
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        // PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom() {
        var position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);

        // // ルームを作成したプレイヤーは、現在のサーバー時刻をゲームの開始時刻に設定する
        // if (PhotonNetwork.IsMasterClient) {
        //     PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        // }
    }
}