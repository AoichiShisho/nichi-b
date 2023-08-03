using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerAccessCallback : MonoBehaviourPunCallbacks
{
    // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player otherPlayer) {
        Debug.Log($"{otherPlayer.NickName}が参加しました");
    }

     // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log($"{otherPlayer.NickName}が退出しました");
    }
}
