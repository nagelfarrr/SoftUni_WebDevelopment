using ForumApp.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data.Data
{
	public class ForumAppDbContext : DbContext
	{
		public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
		{
			this.Database.Migrate();
		}

		private Post FirstPost { get; set; } = null!;
		private Post SecondPost { get; set; } = null!;
		private Post ThirdPost { get; set; } = null!;

		public DbSet<Post> Posts { get; init; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedPosts();
			modelBuilder
				.Entity<Post>()
				.HasData(FirstPost, SecondPost, ThirdPost);

			base.OnModelCreating(modelBuilder);
		}


		private void SeedPosts()
		{
			FirstPost = new Post()
			{
				Id = 1,
				Title = "My first post",
				Content = "My first post will be about performing " + "CRUD operations in MVC. It's so much fun!"
			};

			SecondPost = new Post
			{
				Id = 2,
				Title = "My second post",
				Content = "This is my second post. " + "CRUD operations in MVC are getting more and more interesting!"
			};

			ThirdPost = new Post
			{
				Id = 3,
				Title = "My third post.",
				Content = "Hello there! I'm getting better and better with the " + "CRUD operations in MVC. Stay tuned!"
			};
		}
	}

}

