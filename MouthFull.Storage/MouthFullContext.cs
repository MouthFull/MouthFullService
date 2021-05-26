using Microsoft.EntityFrameworkCore;
using MouthFull.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouthFull.Storage
{
  public class MouthFullContext : DbContext
  {
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RecipeSummary> RecipeSummaries { get; set; }

    public MouthFullContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      modelbuilder.Entity<Ingredient>().HasKey(e => e.EntityId);
      modelbuilder.Entity<Recipe>().HasKey(e => e.EntityId);
      modelbuilder.Entity<User>().HasKey(e => e.EntityId);
      modelbuilder.Entity<RecipeSummary>().HasKey(e => e.EntityId);
    }


  }
}
