namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusColumn_ToDoTask_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ToDoTasks", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoTasks", "DueDate");
            DropColumn("dbo.ToDoTasks", "Status");
        }
    }
}
