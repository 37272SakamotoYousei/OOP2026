using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;

//Program.cs で登録した接続設定を受け取る
public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { //受け取った設定をクラスへ渡す
    }

    //CategorysテーブルをCategory型として問い合わせるためのプロパティ
    public DbSet<Category> Categories => Set<Category>(); //カテゴリ
    //ProductsテーブルをProduct型として問い合わせるためのプロパティ
    public DbSet<Product> Products => Set<Product>(); //商品
}