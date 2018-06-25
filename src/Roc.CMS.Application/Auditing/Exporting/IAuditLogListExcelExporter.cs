using System.Collections.Generic;
using Roc.CMS.Auditing.Dto;
using Roc.CMS.Dto;

namespace Roc.CMS.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
