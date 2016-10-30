namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoNomeTabela : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ListaEmailsModels", newName: "Emails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Emails", newName: "ListaEmailsModels");
        }
    }
}
