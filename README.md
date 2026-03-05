# FluentMermaid
![Nuget version](https://img.shields.io/nuget/v/FluentMermaid?color=blue)

.NET api for generating mermaid syntax markdown that then could be rendered with [Mermaid.js](https://mermaid.js.org/)

Supported platforms: `.netstandard 2.0`

Tested with Mermaid js [v11.12.3](https://github.com/mermaid-js/mermaid/releases/tag/mermaid%4011.12.3)

### For examples look at [WIKI repo page](https://github.com/wowbios/FluentMermaid/wiki/)

## Flowchart API status (Mermaid v11)

- Backward compatible API: `FlowChart.Create(...)` and existing `TextNode/Link/SubGraph/Interaction/Styling`.
- Advanced additive API: `FlowChart.CreateAdvanced(...)`.

### Coverage matrix

- Legacy shapes (`[]`, `()`, `(( ))`, `{{ }}` etc): supported.
- Expanded shapes syntax (`A@{ shape: ... }`): supported via `CreateAdvanced` + `TextNode(string, string shapeAlias)`.
- Special shapes `icon` / `image`: supported via `IconNode(...)` / `ImageNode(...)`.
- Edge IDs (`e1@-->`) and edge-level options (`animate/animation/curve`): supported via advanced `Link(... edgeId ...)` + `EdgeStyling`.
- Link styles (`linkStyle` index/default): supported via `EdgeStyling`.

### Quick examples

```csharp
using FluentMermaid.Enums;
using FluentMermaid.Flowchart;
using FluentMermaid.Flowchart.Enum;

var chart = FlowChart.CreateAdvanced(Orientation.LeftToRight);

var a = chart.TextNode("Manual input", AdvancedShape.SlopedRectangle);
var b = chart.IconNode("fa:user", "User Icon", "square", "t", 60);
var c = chart.ImageNode(new Uri("https://example.com/image.png"), "Image", "t", 60, 60, false);

chart.Link(a, b, "e1", Link.Arrow, "", 1);
chart.Link(b, c, Link.Thick, "next", 1); // old API still works

chart.EdgeStyling.SetAnimated("e1");
chart.EdgeStyling.SetAnimation("e1", EdgeAnimationSpeed.Fast);
chart.EdgeStyling.SetCurve("e1", EdgeCurve.Linear);
chart.EdgeStyling.LinkStyleDefault("color:blue");

var mermaid = chart.Render();
```

# Roadmap
- [x] [Flowchart](https://mermaid.js.org/syntax/flowchart.html)
- [x] [Sequence diagram](https://mermaid.js.org/syntax/sequenceDiagram.html)
- [x] [Class diagram](https://mermaid.js.org/syntax/classDiagram.html)
- [x] [Pie chart](https://mermaid.js.org/syntax/pie.html)
- [x] [State diagram](https://mermaid.js.org/syntax/stateDiagram.html)
- [ ] [Entity relationship](https://mermaid.js.org/syntax/entityRelationshipDiagram.html) https://github.com/wowbios/FluentMermaid/issues/18
- [ ] [User journey](https://mermaid.js.org/syntax/userJourney.html) https://github.com/wowbios/FluentMermaid/issues/19
- [ ] [Gantt](https://mermaid.js.org/syntax/gantt.html) https://github.com/wowbios/FluentMermaid/issues/20
- [ ] [Requirement](https://mermaid.js.org/syntax/requirementDiagram.html) https://github.com/wowbios/FluentMermaid/issues/21
- [ ] [Git graph](https://mermaid.js.org/syntax/gitgraph.html) https://github.com/wowbios/FluentMermaid/issues/22
- [ ] Flowchart fluent API https://github.com/wowbios/FluentMermaid/issues/15
- [ ] Class diagram fluent API https://github.com/wowbios/FluentMermaid/issues/16
