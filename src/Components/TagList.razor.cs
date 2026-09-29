using Microsoft.AspNetCore.Components;

namespace ScissorHands.Theme.MinimalBlog.Components;

public partial class TagList : ComponentBase
{
    /// <summary>
    /// Gets or sets the collection of tags to display.
    /// </summary>
    [Parameter]
    public IEnumerable<string> Tags { get; set; } = [];

    /// <summary>
    /// Gets or sets the CSS class to apply to the tag list.
    /// </summary>
    [Parameter]
    public string CssClass { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the function used to create tag URLs.
    /// </summary>
    [Parameter]
    public Func<string, string>? TagUrlFactory { get; set; }
}
