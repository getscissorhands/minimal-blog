using Microsoft.AspNetCore.Components;
using ScissorHands.Core.Manifests;
using ScissorHands.Core.Models;

namespace ScissorHands.Theme.MinimalBlog.Components.Header;

public partial class Header
{
    /// <summary>
    /// Gets or sets the <see cref="SiteManifest"/> instance.
    /// </summary>
    [CascadingParameter]
    public SiteManifest? Site { get; set; }

    /// <summary>
    /// Gets or sets the engine-prepared navigation hierarchy.
    /// </summary>
    [Parameter]
    public IReadOnlyList<NavigationNode> NavigationTree { get; set; } = [];

    [Parameter]
    public string HomeUrl { get; set; } = ".";

    [Parameter]
    public string? TagIndexUrl { get; set; }
}
