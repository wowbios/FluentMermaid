using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Interfaces;

public interface IEdgeStyling : INode
{
    void SetAnimated(string edgeId, bool value = true);

    void SetAnimation(string edgeId, EdgeAnimationSpeed speed);

    void SetCurve(string edgeId, EdgeCurve curve);

    void SetClass(string edgeId, string className);

    void LinkStyle(int linkIndex, string css);

    void LinkStyle(IEnumerable<int> linkIndexes, string css);

    void LinkStyleDefault(string css);
}
