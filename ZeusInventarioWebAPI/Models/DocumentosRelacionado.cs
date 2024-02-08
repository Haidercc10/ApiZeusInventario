using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models;

[Keyless]
[Index("Importador", Name = "IX_DocumentosRelacionados")]
[Index("TipoImportador", Name = "IX_DocumentosRelacionados_1")]
[Index("Exportador", Name = "IX_DocumentosRelacionados_2")]
[Index("TipoExportador", Name = "IX_DocumentosRelacionados_3")]
[Index("Importador", "TipoImportador", Name = "IX_DocumentosRelacionados_4")]
[Index("Exportador", "TipoExportador", Name = "IX_DocumentosRelacionados_5")]
[Index("TipoImportador", "TipoExportador", "Exportador", "Importador", Name = "IX_DocumentosRelacionados_6")]
public partial class DocumentosRelacionado
{
    [Column(TypeName = "numeric(18, 0)")]
    public decimal Importador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal TipoImportador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Exportador { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal TipoExportador { get; set; }

    [Column("Iden_documentosrelacionados")]
    public int IdenDocumentosrelacionados { get; set; }
}
