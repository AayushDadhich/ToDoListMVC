namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDueDateToDateTime2_ToDoTask_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoTasks", "DueDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoTasks", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
