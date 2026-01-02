using MainLayout = ScissorHands.Theme.MinimalBlog.MainLayout;
using IndexView = ScissorHands.Theme.MinimalBlog.IndexView;
using PostView = ScissorHands.Theme.MinimalBlog.PostView;
using PageView = ScissorHands.Theme.MinimalBlog.PageView;
using NotFoundView = ScissorHands.Theme.MinimalBlog.NotFoundView;

using ScissorHands.Web;

var app = new ScissorHandsApplicationBuilder(args)
              .AddLayouts<MainLayout, IndexView, PostView, PageView, NotFoundView>()
              .Build();
await app.RunAsync();