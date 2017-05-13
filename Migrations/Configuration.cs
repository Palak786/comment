using Microsoft.Ajax.Utilities;
using Music.Models;

namespaceMusic.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<CommentDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(CommentDb context)
		{
			
			//
			context.Comment.AddOrUpdate(
			  m => m.Title,
			  new comment
			  {
				  Title = "Doing coding",
				 Description = "looking for internship h f ugudhj",
			  },
			   new comment
			   {
				   Title = "Hey ay",
				   Description = "looking for internship h f ut oigutigudhj",
			   },
			   new Music
			   {
				   Title = "lets do study",
				 Description = "looking for internship h f ugudhj",
			   },

			);
		}
	}
}
