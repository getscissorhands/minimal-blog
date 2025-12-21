using MainLayout = ScissorHands.Theme.MinimalBlog.MainLayout;
using IndexView = ScissorHands.Theme.MinimalBlog.IndexView;
using PostView = ScissorHands.Theme.MinimalBlog.PostView;
using PageView = ScissorHands.Theme.MinimalBlog.PageView;

using ScissorHands.Web;

var app = await new ScissorHandsApplication<MainLayout, IndexView, PostView, PageView>(args)
                    .VerifyCommandArguments()
                    .BuildAsync();
await app.RunAsync();