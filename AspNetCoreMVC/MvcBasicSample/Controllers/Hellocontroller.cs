using Microsoft.AspNetCore.Mvc;

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class Hellocontroller : Controller{

    // ../Hello/Indexで呼び出されるAction
    public IActionResult Index() {
        //viewを使用せず文字列をHTTPの応答として返す
        //return Content("初めてのASP.NET Core");
        return View();
    }
}
