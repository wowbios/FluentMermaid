using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;
using FluentMermaid.ClassDiagram.Nodes;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IClass : IRenderTo<StringBuilder>
{
    ITypeName Name { get; }

    IClassMemberFunction AddFunction(string name, ITypeName? returnType, Visibility? visibility, params FunctionArgument[] arguments);

    IClassMemberProperty AddProperty(string name, ITypeName? type, Visibility? visibility);
}