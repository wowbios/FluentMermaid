namespace FluentMermaid;

public interface IRenderTo<in TTarget>
{
    void RenderTo(TTarget target);
}