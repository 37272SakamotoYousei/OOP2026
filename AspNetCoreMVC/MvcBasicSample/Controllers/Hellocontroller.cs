using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class Hellocontroller : Controller{

    // ../Hello/Indexで呼び出されるAction
    public IActionResult Index() {
        //商品一件のオブジェクトを作る
        var product = new List<Product> {
            new Product {
            Name = "ハンバーガー",
            Price = 500
        },
        new Product {
            Name = "ポテト",
            Price = 250
        }
        };
        return View(product);
    }
}
