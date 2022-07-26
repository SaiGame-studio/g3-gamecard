using UnityEngine;

public class CardMovement : SaiMonoBehaviour
{
    public virtual void FaceDown()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.z = 180f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }

    public virtual void FaceUp()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.z = 0f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }

    public virtual void ToHorizontal()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.y = 90f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }

    public virtual void ToVertical()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.y = 0f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }
}
