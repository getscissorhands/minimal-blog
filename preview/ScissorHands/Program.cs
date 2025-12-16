using ScissorHands.Theme.MinimalBlog;
using ScissorHands.Web;

var app = await new ScissorHandsApplication<MainLayout, IndexView, PostView, PageView>(args)
                    .VerifyCommandArguments()
                    .BuildAsync();
await app.RunAsync();