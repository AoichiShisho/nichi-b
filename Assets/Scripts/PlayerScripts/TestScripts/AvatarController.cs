using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviourPunCallbacks, IPunObservable
{
    private const float MaxStamina = 6f;
    private float currentStamina = MaxStamina;

    [SerializeField]
    private Image staminaBar = default;

    // Update is called once per frame
    private void Update()
    {
        if (photonView.IsMine) {
            var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (input.sqrMagnitude > 0f) {
                // 入力があったら、スタミナを減少させる
                currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);
                transform.Translate(6f * Time.deltaTime * input.normalized);
            } else {
                currentStamina = Mathf.Min(currentStamina + Time.deltaTime * 2, MaxStamina);
            }
        }
        // スタミナをゲージに反映する
        staminaBar.fillAmount = currentStamina / MaxStamina;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            // 自身のアバターのスタミナを送信する
            stream.SendNext(currentStamina);
        } else {
            // 他プレイヤーのアバターのスタミナを受信する
            currentStamina = (float)stream.ReceiveNext();
        } 
    }
}
