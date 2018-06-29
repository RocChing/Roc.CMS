using Microsoft.EntityFrameworkCore;
using Roc.CMS.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roc.CMS.Content;
using Roc.CMS;
namespace Roc.CMS.Migrations.Seed.Host
{
    public class DefaultCategoryCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public DefaultCategoryCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCategroy();
        }

        private void CreateCategroy()
        {
            var rootCategory = _context.Categorys.IgnoreQueryFilters().FirstOrDefault(m => m.ParentId == 0);
            if (rootCategory == null)
            {
                Category model = new Category()
                {
                    Name = "总分类",
                    ParentId = 0,
                    IsNav = false,
                    IsSpecial = false
                };
                _context.Categorys.Add(model);
                _context.SaveChanges();
            }
        }
    }
}
