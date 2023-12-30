using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Routine.Domain.Entities;

namespace Routine.Infrastructure.Configs;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Introduction).HasMaxLength(500);

        // 初始数据
        builder.HasData(
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                Name = "Microsoft",
                Introduction = "Great Company",
            }, 
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                Name = "Google",
                Introduction = "Don't be evil",
            },
            new Company
             {
                 Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542853"),
                 Name = "Alipapa",
                 Introduction = "Fubao Company",
             },
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df59237100"),
                Name = "Tencent",
                Introduction = "From Shenzhen",
            },
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716400"),
                Name = "Baidu",
                Introduction = "From Beijing",
            },
            new Company
            {
                Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542800"),
                Name = "Adobe",
                Introduction = "Photoshop?",
            },
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df59237111"),
                Name = "SpaceX",
                Introduction = "Wow",
            },
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716411"),
                Name = "AC Milan",
                Introduction = "Football Club",
            },
            new Company
            {
                Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542811"),
                Name = "Suning",
                Introduction = "From Jiangsu",
            },
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df59237122"),
                Name = "Twitter",
                Introduction = "Blocked",
            },
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716422"),
                Name = "Youtube",
                Introduction = "Blocked",
            },
            new Company
            {
                Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542822"),
                Name = "360",
                Introduction = "- -",
            },
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df59237133"),
                Name = "Jingdong",
                Introduction = "Brothers",
            },
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716433"),
                Name = "NetEase",
                Introduction = "Music?",
            },
            new Company
            {
                Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542833"),
                Name = "Amazon",
                Introduction = "Store",
            },
            new Company
            {
                Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df59237144"),
                Name = "AOL",
                Introduction = "Not Exists?",
            },
            new Company
            {
                Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716444"),
                Name = "Yahoo",
                Introduction = "Who?",
            },
            new Company
            {
                Id = Guid.Parse("5efc910b-2f45-43df-afae-620d40542844"),
                Name = "Firefox",
                Introduction = "Is it a company?",
            });
    }
}
