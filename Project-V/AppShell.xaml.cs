namespace Project_V;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //注册非视觉层次页面路由，所有路由名称需保持唯一，它们是全局的
        //当导航到视觉层次结构中的路由时，并不会创建导航堆栈；但导航到非视觉层次页面路由时，创建导航堆栈
        Routing.RegisterRoute("floating", typeof(FloatingPage));


        //也可以将路由注册到不同的视觉层次结构上，可以实现跟踪当前路由层次，导航到不同的页面
        //如下例中，都是导航到detail，但在dogs路由层次结构中时，将导航到DogDetail；反之，将导航到MonkeyDetail
        //Routing.RegisterRoute("dogs/detail", typeof(DogDetail));
        //Routing.RegisterRoute("monkeys/detail", typeof(MonkeyDetail));
    }
}
