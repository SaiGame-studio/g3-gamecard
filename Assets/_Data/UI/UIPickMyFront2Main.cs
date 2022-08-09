using System.Collections.Generic;

public class UIPickMyFront2Main : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerMyDesk.Instance.Line2Desk(LineType.FrontLines, 0, LineType.mainDesk);
    }
}
