// <auto-generated />
namespace DBStorage.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class RemoveDangerousLicenseNumberFromVehcileTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemoveDangerousLicenseNumberFromVehcileTable));
        
        string IMigrationMetadata.Id
        {
            get { return "201802021032126_RemoveDangerousLicenseNumberFromVehcileTable"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}