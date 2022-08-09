using UnityEngine;

public class CardMovement : SaiMonoBehaviour
{
    [SerializeField] protected bool isAttack = true;

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

    public virtual void SwitchPosition()
    {
        this.isAttack = !this.isAttack;
        if (this.isAttack) this.ToAttack();
        else this.ToDefence();
    }

    public virtual void ToAttack()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.y = 0f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }

    public virtual void ToDefence()
    {
        Quaternion quaternion = transform.parent.rotation;
        Vector3 rotation = quaternion.eulerAngles;
        rotation.y = 90f;

        transform.parent.rotation = Quaternion.Euler(rotation);
    }
}
