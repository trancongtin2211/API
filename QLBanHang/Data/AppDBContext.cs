using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLBanHang.Models;

namespace QLBanHang.Data
{
    public class AppDBContext : DbContext
    {
    public DbSet<User> User {get; set;}
    public DbSet<Item> Item {get; set;}
    public DbSet<Category> Category {get; set;}
    public DbSet<Guest> Guest {get; set;}
    public DbSet<GuestTable> GuestTable {get; set;}
    public DbSet<ItemImage> ItemImage {get; set;}
    public DbSet<Order> Order {get; set;}
    public DbSet<OrderItem> OrderItem {get; set;}
    public DbSet<Role> Role {get; set;}
    public DbSet<Status> Status {get; set;}
    public DbSet<Unit> Unit {get; set;}
    public DbSet<UnitType> UnitType {get; set;}
    public DbSet<Restaurant> Restaurant {get; set;}
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    }

}
