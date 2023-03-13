namespace DoAnWebBanCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KTBangChungThuc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quyen",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.RoleName, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.QuyenNguoiDung",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Quyen", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.NguoiDung", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDung", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.DangNhapNguoiDung",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.NguoiDung", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuyenNguoiDung", "UserId", "dbo.NguoiDung");
            DropForeignKey("dbo.DangNhapNguoiDung", "UserId", "dbo.NguoiDung");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuyenNguoiDung", "RoleId", "dbo.Quyen");
            DropIndex("dbo.DangNhapNguoiDung", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.NguoiDung", "UserNameIndex");
            DropIndex("dbo.QuyenNguoiDung", new[] { "RoleId" });
            DropIndex("dbo.QuyenNguoiDung", new[] { "UserId" });
            DropIndex("dbo.Quyen", "RoleNameIndex");
            DropTable("dbo.DangNhapNguoiDung");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.QuyenNguoiDung");
            DropTable("dbo.Quyen");
        }
    }
}
