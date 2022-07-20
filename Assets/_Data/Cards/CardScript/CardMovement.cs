using UnityEngine;

public class CardMovement : SaiMonoBehaviour
{
    [SerializeField] protected Vector3 faceDownRotation = new Vector3(0,0,180f);

    public virtual void FaceDown()
    {
        transform.parent.rotation = Quaternion.Euler(this.faceDownRotation);
    }
}
