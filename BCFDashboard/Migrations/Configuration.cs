namespace BCFDashboard.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BCFDashboard.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BCFDashboard.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BCFDashboard.Models.ApplicationDbContext context)
        {
            context.Projects.AddOrUpdate(p => p.projectId,
                new Project
                {
                    project_id = "3c34c9b3-1b9b-4750-a4f3-0641d58fe48e",
                    name = "My first BCF project",
                    bimsync_project_name = "My bimsync project",
                    bimsync_project_id = "08b7c8adf14a4805a2c34681ab3869af"
                }
                );

            context.Topics.AddOrUpdate(p => p.topicId,
                new Topic
                {
                    guid = "33a62c72-b81d-476d-98c0-662d8775f057",
                    topic_type = "Error",
                    topic_status = "Closed",
                    title = "Wall is misplaced",
                    creation_date = "Mon Jan 18 12:40:50 CEST 2016",
                    modified_date = "Mon Jan 18 12:42:52 CEST 2016",
                    modified_author = "user1@test.com",
                    assigned_to = "user2@test.com"
                }
                );

            context.Comments.AddOrUpdate(p => p.commentID,
                new Comment
                {
                    guid = "d13fd9fa-2f54-4bbd-b37d-15a975077cd3",
                    verbal_status = "Open",
                    status = "Warning",
                    date = "Mon Jan 18 12:43:48 CEST 2016",
                    author = "user2@test.com",
                    comment = "Check this",
                    topic_guid = "6411ce04-5391-40a6-97c2-be0ca45fcc96",
                    viewpoint_guid = "9d3b9d8e-68a8-4f15-bf1e-37fb6bbaf0d5"
                }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
