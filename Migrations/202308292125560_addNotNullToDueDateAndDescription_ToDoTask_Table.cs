namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotNullToDueDateAndDescription_ToDoTask_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoTasks", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoTasks", "Description", c => c.String());
        }
    }
}
