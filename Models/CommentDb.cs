using System.Data.Entity;

namespace Comment.Models
{
	public class CommentDb:DbContext
	{
		public DbSet<comment> comment { get; set; }
	}
}