﻿namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovie2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
