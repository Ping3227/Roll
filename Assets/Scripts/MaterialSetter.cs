using UnityEngine;

public class MaterialSetter : MonoBehaviour, IVisitable
{
    [SerializeField] bool enableSwitch = true;
    public void Accept(IVisitor visitor)
    {
        if (enableSwitch)
        {
            visitor.Visit(this);
        }
    }
}