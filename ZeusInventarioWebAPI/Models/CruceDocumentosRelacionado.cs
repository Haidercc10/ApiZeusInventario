using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models;

[Keyless]
[Table("Cruce_DocumentosRelacionados")]
[Index("SpId", Name = "IX_Cruce_DocumentosRelacionados")]
[Index("SpId", "TipoExportador", "Exportador", "TipoImportador", "Importador", Name = "IX_Cruce_DocumentosRelacionados_1")]
public partial class CruceDocumentosRelacionado
{
    public int? SpId { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Importador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? TipoImportador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Exportador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? TipoExportador { get; set; }
}
