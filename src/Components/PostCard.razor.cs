using Microsoft.AspNetCore.Components;
using ScissorHands.Core.Models;
using ScissorHands.Theme;

namespace ScissorHands.Theme.MinimalBlog.Components;

public partial class PostCard : ComponentBase
{
    [CascadingParameter]
    public LocaleContext? LocaleContext { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ContentDocument"/> instance.
    /// </summary>
    [Parameter]
    public ContentDocument Post { get; set; } = new();

    /// <summary>
    /// Gets or sets the post URL.
    /// </summary>
    [Parameter]
    public string ContentUrl { get; set; } = ".";

    /// <summary>
    /// Gets or sets the function used to create tag URLs.
    /// </summary>
    [Parameter]
    public Func<string, string>? TagUrlFactory { get; set; }

    /// <summary>
    /// Gets or sets the maximum length of the description to display.
    /// </summary>
    [Parameter]
    public int MaxDescriptionLength { get; set; } = 150;

    /// <summary>
    /// Gets or sets a value indicating whether the post card is for the empty content.
    /// </summary>
    [Parameter]
    public bool IsEmpty { get; set; }

    private string GetTruncatedDescription()
    {
        if (string.IsNullOrWhiteSpace(Post.Metadata.Description))
        {
            return string.Empty;
        }

        if (Post.Metadata.Description.Length <= MaxDescriptionLength)
        {
            return Post.Metadata.Description;
        }

        return $"{Post.Metadata.Description.Substring(0, MaxDescriptionLength)}...";
    }
}
