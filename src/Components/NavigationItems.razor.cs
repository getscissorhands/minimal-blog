using Microsoft.AspNetCore.Components;
using ScissorHands.Core.Models;

namespace ScissorHands.Theme.MinimalBlog.Components;

public partial class NavigationItems : ComponentBase
{
    [Parameter]
    public IReadOnlyList<NavigationNode> Nodes { get; set; } = [];
}
