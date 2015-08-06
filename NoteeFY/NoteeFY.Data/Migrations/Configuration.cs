namespace NoteeFY.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NoteeFY.Data.DBContext.NoteeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NoteeFY.Data.DBContext.NoteeContext context)
        {
            context.Notes.AddOrUpdate
                (n => n.NoteID,
                    new Note { Title = "New note", Type = 0, Text = "Hello world!" },
                    new Note { Title = "Note", Type = 0, Text = "World!" }
                );
        }
    }
}
